using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    /// <summary>
    /// Tests for the Condition class
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class SimpleConditionTests
    {
        /// <summary>
        /// Tests that a true condition succeeds
        /// </summary>
        [Test]
        public void IsTrueSuccess()
        {
            Condition.IsTrue(true);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests that a false value causes an exception
        /// </summary>
        [Test]
        public void IsTrueFails()
        {
            Assert.Throws<ConditionException>(() => Condition.IsTrue(false));
        }

        /// <summary>
        /// Tests that a false condition succeeds
        /// </summary>
        [Test]
        public void IsFalseSuccess()
        {
            Condition.IsFalse(false);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests that a true value causes an exception
        /// </summary>
        [Test]
        public void IsFalseFails()
        {
            Assert.Throws<ConditionException>(() => Condition.IsFalse(true));
        }

        [Test]
        public void IsNotNullSuccess()
        {
            Condition.IsNotNull("Hello World");
            Assert.IsTrue(true);
        }

        [Test]
        public void IsNotNullFailure()
        {
            Assert.Throws<ConditionException>(() => Condition.IsNotNull((string)null));
            Assert.IsTrue(true);
        }

        [Test]
        public void IsNullSuccess()
        {
            Condition.IsNull((string)null);
            Assert.IsTrue(true);
        }

        [Test]
        public void IsNullFailure()
        {
            Assert.Throws<ConditionException>(() => Condition.IsNull("Hello World"));
            Assert.IsTrue(true);
        }


        [Test]
        public void InRangeSuccess()
        {
            Condition.InRange(2, 456, 52);
            Assert.IsTrue(true);
        }

        [Test]
        public void InRangeSuccessStart()
        {
            Condition.InRange(2, 456, 2);
            Assert.IsTrue(true);
        }

        [Test]
        public void InRangeSuccessEnd()
        {
            Condition.InRange(2, 456, 456);
            Assert.IsTrue(true);
        }

        [Test]
        public void InRangeFailure()
        {
            Assert.Throws<ConditionException>(() => Condition.InRange(2, 456, 999));
        }
    }

}
