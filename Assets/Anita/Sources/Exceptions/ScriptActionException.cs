using System;

namespace Anita.Exceptions
{
    public class ScriptActionException : Exception
    {
        public ScriptActionException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}