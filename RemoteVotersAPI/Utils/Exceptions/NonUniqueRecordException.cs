using System;
using System.Runtime.Serialization;

namespace remotevotersapi.Application.Services
{
    /// <summary>
    /// Non Unique Record Exception
    ///
    /// Author: FStrony
    /// </summary>
    [Serializable]
    internal class NonUniqueRecordException : Exception
    {
        public NonUniqueRecordException()
        {
        }

        public NonUniqueRecordException(string message) : base(message)
        {
        }

        public NonUniqueRecordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonUniqueRecordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}