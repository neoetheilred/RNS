using RNSLib;
using System;

namespace RNSMachine
{
    public partial class Machine
    {
        private int _position = 0;
        private bool _checkDiv = false;
        public bool End => _position >= _code.Length;
        public void StepOver()
        {
            OpCodes commandCode = ReadCommand();
            _lastExecuted = $"{commandCode}";
            switch (commandCode)
            {
                case OpCodes.DUP:
                    Dup();
                    break;
                case OpCodes.PUSH:
                    Push();
                    break;
                case OpCodes.POP:
                    Pop();
                    break;
                case OpCodes.ADD:
                    Add();
                    break;
                case OpCodes.DIV:
                    Div();
                    break;
                case OpCodes.MOD:
                    Mod();
                    break;
                case OpCodes.SUB:
                    Sub();
                    break;
                case OpCodes.MUL:
                    Mul();
                    break;
                case OpCodes.TDC:
                    Tdc();
                    break;
                case OpCodes.PUSHR:
                    PushR();
                    break;
                case OpCodes.CMP:
                    Cmp();
                    break;
                case OpCodes.JMP: 
                    Jmp();
                    break;
                case OpCodes.JEQ:
                    Jeq();
                    break;
                case OpCodes.JNE:
                    Jne();
                    break;
                case OpCodes.JLT:
                    Jlt();
                    break;
                case OpCodes.JGT:
                    Jgt();
                    break;
                case OpCodes.JLE:
                    Jle();
                    break;
                case OpCodes.JGE:
                    Jge();
                    break;
                case OpCodes.NEG:
                    Neg();
                    break;
                default:
                    throw new RNSRuntimeException($"Not supported: {commandCode}");
            }
        }

        #region Utility

        private OpCodes ReadCommand()
        {
            return (OpCodes)_code[_position++];
        }

        private RNSNumber ReadRnsNumber()
        {
            uint[] remainders = new uint[RNSNumber.Modules.Length];

            for (var i = 0; i < remainders.Length; ++i)
            {
                remainders[i] = BitConverter.ToUInt32(_code, _position);
                _position += 4;
            }

            return RNSNumber.FromRemainders(remainders);
        }

        private int ReadPosition()
        {
            try
            {
                return BitConverter.ToInt32(_code, _position);
            }
            finally
            {
                _position += 4;
            }
        }

        private Registers ReadRegister()
        {
            return (Registers)_code[_position++];
        }

        private void SetRegister(Registers reg, RNSNumber value)
        {
            switch (reg)
            {
                case Registers.A: A = value; break;
                case Registers.B: B = value; break;
                default: throw new RNSRuntimeException($"Register {reg} is read-only");
            }
        }

        #endregion

        #region Commands

        private void Neg()
        {
            R = -A;
        }

        private void Dup()
        {
            _valueStack.Push(_valueStack.Peek());
        }

        private void Jeq()
        {
            int pos = ReadPosition();
            if (C == 0)
            {
                _position = pos;
            }
        }

        private void Jne()
        {
            int pos = ReadPosition();
            if (C != 0)
            {
                _position = pos;
            }
        }

        private void Jlt()
        {
            int pos = ReadPosition();
            if (C < 0)
            {
                _position = pos;
            }
        }

        private void Jgt()
        {
            int pos = ReadPosition();
            if (C > 0)
            {
                _position = pos;
            }
        }

        private void Jle()
        {
            int pos = ReadPosition();
            if (C <= 0)
            {
                _position = pos;
            }
        }

        private void Jge()
        {
            int pos = ReadPosition();
            if (C >= 0)
            {
                _position = pos;
            }
        }

        private void Jmp()
        {
            _position = ReadPosition();
        }

        private void Cmp()
        {
            C = A.CompareTo(B);
        }

        private void PushR()
        {
            _valueStack.Push(R);
        }

        private void Tdc()
        {
            _checkDiv = !_checkDiv;
        }

        private void Add()
        {
            R = A + B;
        }

        private void Sub()
        {
            R = A - B;
        }

        private void Mul()
        {
            R = A * B;
        }

        private void Mod()
        {
            R = A % B;
        }

        private void Div()
        {
            try
            {
                R = A / B;
            }
            catch (RNSException) when (_checkDiv)
            {
                R = RNSNumber.FromBigInteger(A.ToSignedBigInteger() / B.ToSignedBigInteger());
            }
        }

        private void Pop()
        {
            Registers reg = ReadRegister();
            _lastExecuted += $" {reg}";
            SetRegister(reg, _valueStack.Pop());
        }

        private void Push()
        {
            RNSNumber number = ReadRnsNumber();
            _lastExecuted += $" {number.ToSignedBigInteger()}";
            _valueStack.Push(number);
        }

        #endregion
    }
}