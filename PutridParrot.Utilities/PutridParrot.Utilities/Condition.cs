using System;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// The class is cannot be instantiated, but is used for static methods
    /// which test conditions like asserts. These might be used as preconditions
    /// for a method and will throw a ConditionException
    /// </summary>
    public static class Condition
    {
        /// <summary>
        /// Used bu conditions to supply user defined handling of failures
        /// </summary>
        public delegate void ConditionFailureDelegate();

        #region IsTrue Condition
        /// <summary>
        /// Tests whether the given value is true.
        /// </summary>
        /// <param name="value">The boolean to test against</param>
        public static void IsTrue(bool value)
        {
            IsTrue(value, "The condition was not true");
        }
        /// <summary>
        /// Tests whether the given value is true, if it is not then an exception
        /// is thrown with the supplied message.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void IsTrue(bool value, string message)
        {
            IsTrue(value, () => throw new ConditionException(message));
        }

        /// <summary>
        /// Tests whether the given value is true, if it is not then the supplied
        /// delegate is called.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="failureDelegate"></param>
        public static void IsTrue(bool value, ConditionFailureDelegate failureDelegate)
        {
            if (value != true)
            {
                failureDelegate?.Invoke();
            }
        }
        #endregion

        #region IsFalse Condition
        /// <summary>
        /// Tests whether a given value is false.
        /// </summary>
        /// <param name="value">The boolean to test against</param>
        public static void IsFalse(bool value)
        {
            IsFalse(value, "The condition was not false");
        }
        /// <summary>
        /// Tests whether a given value is false.
        /// </summary>
        /// <param name="value">The boolean to test against</param>
        /// <param name="message"></param>
        public static void IsFalse(bool value, string message)
        {
            IsFalse(value, delegate ()
            {
                throw new ConditionException(message);
            }
            );
        }
        /// <summary>
        /// Tests whether a given value is false.
        /// </summary>
        /// <param name="value">The boolean to test against</param>
        /// <param name="failureDelegate"></param>
        public static void IsFalse(bool value, ConditionFailureDelegate failureDelegate)
        {
            if (value != false)
            {
                if (failureDelegate != null)
                {
                    failureDelegate();
                }
            }
        }
        #endregion

        #region IsNull Condition
        /// <summary>
        /// Tests whether a value is null
        /// </summary>
        /// <param name="value">The object to test against</param>
        public static void IsNull(object value)
        {
            IsNull(value, "The condition was not null");
        }

        /// <summary>
        /// Tests whether a value is null
        /// </summary>
        /// <param name="value">The object to test against</param>
        /// <param name="message"></param>
        public static void IsNull(object value, string message)
        {
            IsNull(value,
                delegate ()
                {
                    throw new ConditionException(message);
                }
            );
        }

        /// <summary>
        /// Tests whether a value is null
        /// </summary>
        /// <param name="value">The object to test against</param>
        /// <param name="failureDelegate"></param>
        public static void IsNull(object value, ConditionFailureDelegate failureDelegate)
        {
            if (value != null)
            {
                if (failureDelegate != null)
                {
                    failureDelegate();
                }
            }
        }
        #endregion

        #region IsNotNull Condition
        /// <summary>
        /// Tests whether a value is not null
        /// </summary>
        /// <param name="value">The object to test against</param>
        public static void IsNotNull(object value)
        {
            IsNotNull(value, "The condition was null");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void IsNotNull(object value, string message)
        {
            IsNotNull(value, delegate ()
            {
                throw new ConditionException(message);
            }
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="failureDelegate"></param>
        public static void IsNotNull(object value, ConditionFailureDelegate failureDelegate)
        {
            if (value == null)
            {
                if (failureDelegate != null)
                {
                    failureDelegate();
                }
            }
        }
        #endregion

        #region Assert Condition
        /// <summary>
        /// A general assert to test whether a value is true. This just 
        /// allows the developer to use a different semantic for their 
        /// conditional test
        /// </summary>
        /// <param name="value">The boolean to test against</param>
        public static void Assert(bool value)
        {
            Assert(value, "The assert was not true");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void Assert(bool value, string message)
        {
            Assert(value, delegate ()
            {
                throw new ConditionException(message);
            }
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="failureDelegate"></param>
        public static void Assert(bool value, ConditionFailureDelegate failureDelegate)
        {
            if (value != true)
            {
                if (failureDelegate != null)
                {
                    failureDelegate();
                }
            }
        }
        #endregion

        #region InRange Condition
        /// <summary>
        /// Tests whether a value is within the supplied range. That is whether
        /// start &lt;= value &lt;= end.
        /// </summary>
        /// <param name="start">The start of the range</param>
        /// <param name="end">The end of the range</param>
        /// <param name="value">The value to test against</param>
        public static void InRange(double start, double end, double value)
        {
            InRange(start, end, value, String.Format("The value {0} was not within the start and end values ({1}, {2})", value, start, end));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void InRange(double start, double end, double value, string message)
        {
            InRange(start, end, value, delegate ()
            {
                throw new ConditionException(message);
            }
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <param name="failureDelegate"></param>
        public static void InRange(double start, double end, double value, ConditionFailureDelegate failureDelegate)
        {
            if (value < start || value > end)
            {
                if (failureDelegate != null)
                {
                    failureDelegate();
                }
            }
        }
        #endregion
    }

}
