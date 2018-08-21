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
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class IfTests
    {
        [Test]
        public void IsNotNull_WithNull_ExpectFalse()
        {
            Assert.IsFalse(If.IsNotNull((string)null));
        }

        [Test]
        public void IsNotNull_WithNonNull_ExpectTrue()
        {
            Assert.IsTrue(If.IsNotNull("Scooby Doo"));
        }

        [Test]
        public void IsNull_WithNull_ExpectTrue()
        {
            Assert.IsTrue(If.IsNull((string)null));
        }

        [Test]
        public void IsNull_WithNonNull_ExpectFalse()
        {
            Assert.IsFalse(If.IsNull("Shaggy"));
        }

        [Test]
        public void IsEmpty_OnEmptyString_ExpectTrue()
        {
            Assert.IsTrue(If.IsEmpty(""));
        }

        [Test]
        public void IsEmpty_OnNonEmptyString_ExpectFalse()
        {
            Assert.IsFalse(If.IsEmpty("Hair bear bunch"));
        }

        [Test]
        public void IsEmpty_OnEmptyCollection_ExpectTrue()
        {
            Assert.IsTrue(If.IsEmpty(new string[0]));
        }

        [Test]
        public void IsEmpty_OnNonEmptyCollection_ExpectFalse()
        {
            Assert.IsFalse(If.IsEmpty(new [] { "Scooby", "Scrappy" }));
        }
    }
}
