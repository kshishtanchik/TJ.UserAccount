using System;
using System.Runtime.Serialization;

namespace TJ.UserAccount.Dao.Exceptions
{
    [Serializable]
    internal class AccountRepoException : Exception
    {
        public AccountRepoException()
        {
        }

        public AccountRepoException(string message) : base(message)
        {
        }

        public AccountRepoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountRepoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}