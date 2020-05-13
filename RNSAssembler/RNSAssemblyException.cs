namespace RNSAssembler.Assembling
{
    [System.Serializable]
    public class RNSAssemblyException : System.Exception
    {
        public RNSAssemblyException() { }
        public RNSAssemblyException(string message) : base(message) { }
        public RNSAssemblyException(string message, System.Exception inner) : base(message, inner) { }
        protected RNSAssemblyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}