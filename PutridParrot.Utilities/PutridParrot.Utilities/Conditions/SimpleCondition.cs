using System;
using System.Collections;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// Condition partial with fastest methods
    /// </summary>
    public static partial class Condition
    {
        public static void IsTrue(bool value, string message = null)
        {
            if (value != true)
            {
                throw new ConditionException(message);
            }
        }

        public static void IsFalse(bool value, string message = null)
        {
            if (value != false)
            {
                throw new ConditionException(message);
            }
        }

        public static void IsNotNull<T>(T value, string message = null)
        {
            if (If.IsNull(value))
            {
                throw new ConditionException(message);
            }
        }

        public static void IsNull<T>(T value, string message = null)
        {
            if (If.IsNotNull(value))
            {
                throw new ConditionException(message);
            }
        }

        public static void IsEmpty<T>(T value, string message = null)
        {
            var s = value as string;
            if (s != null)
            {
                if (If.IsNotEmpty(s))
                {
                    throw new ConditionException(message);
                }
            }
            else
            {
                var collection = value as ICollection;
                if (collection?.Count > 0)
                {
                    throw new ConditionException(message);
                }
            }
        }

        public static void InRange<T>(T lowestInclusive, T highestInclusive, T value, string message = null) where T : IComparable<T>
        {
            if (value.CompareTo(lowestInclusive) < 0 || value.CompareTo(highestInclusive) > 0)
            {
                throw new ConditionException(message);
            }
        }
    }
}
