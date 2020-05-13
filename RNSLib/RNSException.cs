using System;

namespace RNSLib
{
    [Serializable]
    public class RNSException : Exception
    {
        public RNSException() { }
        public RNSException(string message) : base(message) { }
        public RNSException(string message, Exception inner) : base(message, inner) { }
        protected RNSException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}