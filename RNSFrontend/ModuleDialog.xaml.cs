using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RNSLib;

namespace RNSFrontend
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog : Window
    {
        public ModuleDialog()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
        }

        public IEnumerable<uint> Mods = new List<uint>();


        private void SetModules(object sender, RoutedEventArgs e)
        {
            try
            {
                RNSNumber.SetModules(tb.Text.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(uint.Parse).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
