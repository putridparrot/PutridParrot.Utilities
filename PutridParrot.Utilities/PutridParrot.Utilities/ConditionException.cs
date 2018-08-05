using System;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// The ConditionException is used by the Condition static methods when 
    /// a value does not match the condition
    /// </summary>
    [global::System.Serializable]
    public class ConditionException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //            

        /// <summary>
        /// Creates a default instance of the exception
        /// </summary>
        public ConditionException() { }
        /// <summary>
        /// Creates an instance of the object with a given message
        /// </summary>
        /// <param name="message"></param>
        public ConditionException(string message) : base(message) { }
        /// <summary>
        /// Creates an instance of the object with the given message and the inner exception 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ConditionException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ConditionException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}

