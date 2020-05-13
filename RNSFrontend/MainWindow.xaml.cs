using RNSAssembler;
using RNSExpressionCompiler;
using RNSLib;
using RNSMachine;
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RNSFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RNSNumber.ModulesChanged += () =>
            {
                module_status.Content = $"Текущее основание СОК: {{{string.Join(" ", RNSNumber.Modules)}}}";
            };
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                logs.Items.Clear();

                if (!RNSNumber.ModulesAreSet)
                {
                    RNSNumber.SetModules(RNSModuleSets.GetModuleSet(RNSModuleSets.ModuleSets.Default));
                }

                //MakeExec();
                var sw = new StringWriter();
                var sr = new StringReader(tb.Text);
                var expr = new RNSExpression(sw, sr, checkdiv.IsChecked);

                expr.Compile();

                string asm = "asm.asm";
                string exec = "out.bin";

                Utility.WriteToFile(sw.ToString(), asm);
                Console.WriteLine(sw);
                Utility.MakeExec(asm, exec);
                var state = Utility.Execute(exec, logs);
                lb.Content = $"{state.StackBlueprint.Last().ToSignedBigInteger()}";
            }
            catch (RNSException ex)
            { 
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}");
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void SetRnsModules(object sender, RoutedEventArgs e)
        {
            RNSNumber.SetModules(
                RNSModuleSets.GetModuleSet(
                    (RNSModuleSets.ModuleSets)
                    Enum.Parse(typeof(RNSModuleSets.ModuleSets), ((MenuItem)sender).Header.ToString())));
        }

        private void CusomModules(object sender, RoutedEventArgs e)
        {
            ModuleDialog dialog = new ModuleDialog();
            if (dialog.ShowDialog() == true)
            {

            }
        }
    }

    class Utility
    {
        public static MachineState Execute(string exe, ListBox logs)
        {
            if (!File.Exists(exe))
            {
                throw new FileNotFoundException();
            }

            try
            {
                using (var fs = File.Open(exe, FileMode.Open))
                {
                    using (var br = new BinaryReader(fs))
                    {
                        Machine machine = new Machine(br);
                        // machine.PrintBase();
                        while (!machine.End)
                        {
                            var state = machine.GetState();
                            if (new [] {"DIV", "MUL", "ADD", "SUB", "MOD"}.Contains(state.LastExecuted))
                            {
                                ListBoxItem item = new ListBoxItem();
                                TextBox content = new TextBox();
                                content.IsReadOnly = true;
                                content.BorderThickness = new Thickness(0,0,0,0);
                                content.TextWrapping = TextWrapping.Wrap;
                                content.Text = $"{state.A}\r\n{state.B}\r\nДействие: {state.LastExecuted}";
                                content.Width = item.Width;
                                item.Content = content;
                                logs.Items.Add(item);
                            }
                            machine.StepOver();
                        }

                        return machine.GetState();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static void WriteToFile(string s, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (var _ = File.Create(path))
                    {

                    }
                }
                using (var fs = File.Open(path, FileMode.Truncate))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.Write(s);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void MakeExec(string from, string to, bool check_div = false)
        {
            if (!File.Exists(from))
            {
                throw new FileNotFoundException();
            }
            if (!File.Exists(to))
            {
                using (var _ = File.Create(to)) { }
            }
            Assembler assembler = new Assembler();
            string asm = File.ReadAllText(from);
            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(asm))))
            {
                using (var bw = new BinaryWriter(File.Open(to, FileMode.Truncate)))
                {
                    assembler.Assembly(sr, bw, check_div);
                }
            }
        }

        static void WriteCommand(BinaryWriter bw, OpCodes opCode)
        {
            bw.Write((byte)opCode);
        }

        static void WriteReg(BinaryWriter bw, Registers reg)
        {
            bw.Write((byte)reg);
        }

        static void WriteRNS(BinaryWriter bw, RNSNumber number)
        {
            foreach (var u in number)
            {
                bw.Write(u);
            }
        }

        static void WriteDecimal(BinaryWriter bw, BigInteger bigInteger)
        {
            WriteRNS(bw, RNSNumber.FromBigInteger(bigInteger));
        }
    }
}
