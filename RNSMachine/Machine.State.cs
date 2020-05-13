using RNSLib;
using System.Collections.Generic;
using System.Linq;

namespace RNSMachine
{
    public partial class Machine
    {
        /// <summary>
        /// Регистры
        /// </summary>
        #region Registers
        private RNSNumber A;
        private RNSNumber B;
        private RNSNumber R;
        private int C;
        #endregion

        private Stack<RNSNumber> _valueStack = new Stack<RNSNumber>();
        private string _lastExecuted = "";

        public MachineState GetState()
        {
            return new MachineState(A, B, R, C, _lastExecuted, _valueStack.ToList());
        }
    }
}