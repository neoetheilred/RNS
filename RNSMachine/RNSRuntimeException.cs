namespace RNSMachine
{
    [System.Serializable]
    public class RNSRuntimeException : System.Exception
    {
        public RNSRuntimeException() { }
        public RNSRuntimeException(string message) : base(message) { }
        public RNSRuntimeException(string message, System.Exception inner) : base(message, inner) { }
        protected RNSRuntimeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}