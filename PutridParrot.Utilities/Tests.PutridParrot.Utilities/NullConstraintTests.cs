using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class NullConstraintTests
    {
        [Test]
        public void Check_WithNull_ExpectTrue()
        {
            var constraint = new NullConstraint();
            Assert.IsTrue(constraint.Check((string)null));
        }

        [Test]
        public void Check_WithNonNull_ExpectFalse()
        {
            var constraint = new NullConstraint();
            Assert.IsFalse(constraint.Check("Muttly"));
        }
    }
}