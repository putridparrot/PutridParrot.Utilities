using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

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

        public static Range<T> Between(T fromInclusive, T toInclusive)
        {
            return new Range<T>(fromInclusive, toInclusive);
        }

        public T Min { get; }
        public T Max { get; }

        public bool Contains(T value)
        {
            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }

        public bool Contains(Range<T> value)
        {
            return value.Min.CompareTo(Min) >= 0 && value.Max.CompareTo(Max) <= 0;
        }

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

        public bool IsBefore(T value)
        {
            return value.CompareTo(Min) < 0;
        }

        public bool IsAfter(T value)
        {
            return value.CompareTo(Max) > 0;
        }

        public bool IsBefore(Range<T> range)
        {
            return range.Min.CompareTo(Min) < 0;
        }

        public bool IsAfter(Range<T> range)
        {
            return range.Max.CompareTo(Max) > 0;
        }


        public static T GetMin(T a, T b)
        {
            return a.CompareTo(b) < 0 ? a : b;
        }

        public static T GetMax(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public override bool Equals(object obj)
        {
            return obj is Range<T> range && (Min, Max).Equals((range.Min, range.Max));
        }

        public override int GetHashCode()
        {
            return (Min, Max).GetHashCode();
        }
    }

}
