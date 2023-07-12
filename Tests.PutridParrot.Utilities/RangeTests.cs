using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class RangeTests
    {
        [Test]
        public void Min_ExpectLowestValueInRange()
        {
            var range = new Range<int>(20, 50);
            Assert.AreEqual(20, range.Min);
        }

        [Test]
        public void Max_ExpectHighestValueInRange()
        {
            var range = new Range<int>(20, 50);
            Assert.AreEqual(50, range.Max);
        }

        [Test]
        public void Between_Min_ExpectLowestValueInRange()
        {
            var range = Range<int>.Between(20, 50);
            Assert.AreEqual(20, range.Min);
        }

        [Test]
        public void Between_Max_ExpectHighestValueInRange()
        {
            var range = Range<int>.Between(20, 50);
            Assert.AreEqual(50, range.Max);
        }

        [Test]
        public void Contains_SingleValueInsideRange_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(23));
        }

        [Test]
        public void Contains_SingleValueInsideRangeLowest_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(20));
        }

        [Test]
        public void Contains_SingleValueInsideRangeHighest_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(50));
        }

        [Test]
        public void Contains_SingleValueOutsideRange_ExpectFalse()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsFalse(range.Contains(10));
        }

        [Test]
        public void Contains_RangeInsideRange_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(Range<int>.Between(25, 40)));
        }

        [Test]
        public void Contains_RangeInsideRangeLowest_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(Range<int>.Between(20, 40)));
        }

        [Test]
        public void Contains_RangeInsideRangeHighest_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(Range<int>.Between(30, 50)));
        }

        [Test]
        public void Contains_RangeInsideRangeSame_ExpectTrue()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsTrue(range.Contains(Range<int>.Between(20, 50)));
        }

        [Test]
        public void Contains_RangeAllOutsideRange_ExpectFalse()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsFalse(range.Contains(Range<int>.Between(10, 16)));
        }

        [Test]
        public void Contains_RangePartOutsideRange_ExpectFalse()
        {
            var range = Range<int>.Between(20, 50);
            Assert.IsFalse(range.Contains(Range<int>.Between(10, 12)));
        }

        [Test]
        public void Intersection_NoIntersectionLower_ExpectException()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(10, 13);
            Assert.Throws<ArgumentException>(() => r1.Intersection(r2));
        }

        [Test]
        public void Intersection_NoIntersectionHigher_ExpectException()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(51, 60);
            Assert.Throws<ArgumentException>(() => r1.Intersection(r2));
        }

        [Test]
        public void Intersection_WithIntersection_ExpectOverlappingRange()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(10, 25);

            var result = r1.Intersection(r2);
            Assert.AreEqual(20, result.Min);
            Assert.AreEqual(25, result.Max);
        }

        [Test]
        public void Equals_WithSameRange_ExpectTrue()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(20, 50);

            Assert.IsTrue(r1.Equals(r2));
            Assert.IsTrue(r2.Equals(r1));
        }

        [Test]
        public void GetHashCode_WithDifferentRange_ExpectFalse()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(20, 51);

            Assert.IsFalse(r1.GetHashCode() == r2.GetHashCode());
        }

        [Test]
        public void GetHashCode_WithSameRange_ExpectTrue()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(20, 50);

            Assert.IsTrue(r1.GetHashCode() == r2.GetHashCode());
        }

        [Test]
        public void Equals_WithDifferentRange_ExpectFalse()
        {
            var r1 = Range<int>.Between(20, 50);
            var r2 = Range<int>.Between(20, 51);

            Assert.IsFalse(r1.Equals(r2));
            Assert.IsFalse(r2.Equals(r1));
        }

        [Test]
        public void IsBefore_WithValueBeforeRange_ExpectTrue()
        {
            Assert.IsTrue(Range<int>.Between(20, 50).IsBefore(10));
        }

        [Test]
        public void IsBefore_WithValueInRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsBefore(22));
        }

        [Test]
        public void IsBefore_WithValueAfterRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsBefore(60));
        }

        [Test]
        public void IsAfter_WithValueAfterRange_ExpectTrue()
        {
            Assert.IsTrue(Range<int>.Between(20, 50).IsAfter(110));
        }

        [Test]
        public void IsAfter_WithValueInRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsAfter(23));
        }

        [Test]
        public void IsAfter_WithValueBeforeRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsAfter(11));
        }

        [Test]
        public void IsBefore_WithRangeBeforeRange_ExpectTrue()
        {
            Assert.IsTrue(Range<int>.Between(20, 50).IsBefore(Range<int>.Between(10, 12)));
        }

        [Test]
        public void IsBefore_WithRangeInRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsBefore(Range<int>.Between(20, 22)));
        }

        [Test]
        public void IsBefore_WithRangeAfterRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsBefore(Range<int>.Between(55, 150)));
        }

        [Test]
        public void IsAfter_WithRangeAfterRange_ExpectTrue()
        {
            Assert.IsTrue(Range<int>.Between(20, 50).IsAfter(Range<int>.Between(60, 90)));
        }

        [Test]
        public void IsAfter_WithRangeInRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsAfter(Range<int>.Between(25, 43)));
        }

        [Test]
        public void IsAfter_WithRangeBeforeRange_ExpectFalse()
        {
            Assert.IsFalse(Range<int>.Between(20, 50).IsAfter(Range<int>.Between(11, 15)));
        }

    }
}
