using System.Collections;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// If class is simply a set of "standard" if 
    /// tests, in a more "readable" form
    /// </summary>
    public static partial class If
    {
        public static bool IsNotNull<T>(T value)
        {
            return value != null;
        }

        public static bool IsNull<T>(T value)
        {
            return value == null;
        }

        public static bool IsEmpty(string s)
        {
            return s?.Length == 0;
        }

        public static bool IsNotEmpty(string s)
        {
            return s?.Length > 0;
        }

        public static bool IsEmpty(ICollection collection)
        {
            return collection?.Count == 0;
        }

        public static bool IsNotEmpty(ICollection collection)
        {
            return collection?.Count > 0;
        }

        public static bool IsNullOrEmpty(ICollection collection)
        {
            return IsNull(collection) || IsEmpty(collection);
        }

        public static bool IsTrue(bool value)
        {
            return value;
        }

        public static bool IsFalse(bool value)
        {
            return !value;
        }
    }
}
