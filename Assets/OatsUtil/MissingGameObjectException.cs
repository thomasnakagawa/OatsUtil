using System;

namespace OatsUtil
{
    /// <summary>
    /// Exception for when a required GameObject is missing
    /// </summary>
    public class MissingGameObjectException : Exception
    {
        public MissingGameObjectException() {}

        public MissingGameObjectException(string message) : base(message) {}

        public MissingGameObjectException(string message, Exception inner) : base(message, inner) {}
    }
}
