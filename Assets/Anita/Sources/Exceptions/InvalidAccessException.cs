using System;

namespace Anita.Exceptions
{
    public class InvalidAccessException : Exception
    {
        public InvalidAccessException(string message, Exception innerException)
            : base(message, innerException) { }

        public InvalidAccessException(string message)
            : base(message) { }
    }
}