using System;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// Range class can handle any types that support
    /// IComparable&lt;T&gt;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Range<T> where
        T : IComparable<T>
    {
        public Range(T fromInclusive, T toInclusive)
        {
            Min = GetMin(fromInclusive, toInclusive);
            Max = GetMax(toInclusive, toInclusive);
        }

        public static Range<T> Between(T fromInclusive, T toInclusive) =>
            new Range<T>(fromInclusive, toInclusive);

        /// <summary>
        /// Gets the lower-bound or minimum value
        /// </summary>
        public T Min { get; }
        /// <summary>
        /// Gets the upper-bound or maximum value
        /// </summary>
        public T Max { get; }

        /// <summary>
        /// Checks if the supplied value is 
        /// within the range
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value) =>
            value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;

        /// <summary>
        /// Checks whether the supplied range
        /// is fully within this range
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Range<T> value) =>
            value.Min.CompareTo(Min) >= 0 && value.Max.CompareTo(Max) <= 0;

        /// <summary>
        /// Returns the intersection/overlapping
        /// range from this and the supplied range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Range<T> Intersection(Range<T> range)
        {
            var minMin = Min.CompareTo(range.Min) <= 0 ? range.Min : Min;
            var minMax = Max.CompareTo(range.Max) >= 0 ? range.Max : Max;

            if (minMin.CompareTo(minMax) > 0)
            {
                throw new ArgumentException("No intersection found");
            }

            return new Range<T>(minMin, minMax); 
        }

        /// <summary>
        /// IsBefore checks if the supplied value is before
        /// the range, returning true if it is
        /// </summary>
        /// <param name="value">The value to compare against</param>
        /// <returns>True if the value is before the range, otherwise false</returns>
        public bool IsBefore(T value) =>
            value.CompareTo(Min) < 0;

        /// <summary>
        /// IsAfter checks if the supplied value is after
        /// the range, returning true if it is
        /// </summary>
        /// <param name="value">The value to compare against</param>
        /// <returns>True if the value is after the range, otherwise false</returns>
        public bool IsAfter(T value) =>
            value.CompareTo(Max) > 0;

        /// <summary>
        /// IsBefore checks if the supplied Range is before
        /// the range, returning true if it is
        /// </summary>
        /// <param name="range">The range to compare against</param>
        /// <returns>True if the range is before this range, otherwise false</returns>
        public bool IsBefore(Range<T> range) =>
            range.Min.CompareTo(Min) < 0;

        /// <summary>
        /// IsAfter checks if the supplied Range is after
        /// the range, returning true if it is
        /// </summary>
        /// <param name="range">The range to compare against</param>
        /// <returns>True if the range is after this range, otherwise false</returns>
        public bool IsAfter(Range<T> range) =>
            range.Max.CompareTo(Max) > 0;

        /// <summary>
        /// Get's the minimum of two IComparable
        /// values.
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <returns>The value which is before the 
        /// other value, or returns the first item 
        /// if they're the same</returns>
        public static T GetMin(T a, T b) =>
            a.CompareTo(b) < 0 ? a : b;

        /// <summary>
        /// Get's the maximum of two IComparable
        /// values.
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <returns>The value which is after the 
        /// other value, or returns the first item 
        /// if they're the same</returns>
        public static T GetMax(T a, T b) =>
            a.CompareTo(b) > 0 ? a : b;

        /// <summary>
        /// Checks whether the two ranges are
        /// Equal, in that they have the same 
        /// min and max values
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) =>
            obj is Range<T> range && (Min, Max).Equals((range.Min, range.Max));

        /// <summary>
        /// Gets the hashcode of the range
        /// using the min and max values
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            (Min, Max).GetHashCode();
    }
}
