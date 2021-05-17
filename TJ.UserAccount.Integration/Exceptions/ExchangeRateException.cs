using System;
using System.Runtime.Serialization;

namespace TJ.UserAccount.Integration.Exceptions
{
    [Serializable]
    internal class ExchangeRateException : Exception
    {
        public ExchangeRateException()
        {
        }

        public ExchangeRateException(string message) : base(message)
        {
        }

        public ExchangeRateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExchangeRateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}