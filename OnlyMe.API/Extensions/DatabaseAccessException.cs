using System;
using System.Runtime.Serialization;

namespace OnlyMe.API.Extensions
{
    [Serializable]
    internal class DatabaseAccessException : Exception
    {
        public DatabaseAccessException()
        {
        }

        public DatabaseAccessException(string message) : base(message)
        {
        }

        public DatabaseAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DatabaseAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}