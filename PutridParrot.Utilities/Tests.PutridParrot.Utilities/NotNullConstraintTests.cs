using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class NotNullConstraintTests
    {
        [Test]
        public void Check_WithNull_ExpectFalse()
        {
            var constraint = new NotNullConstraint();
            Assert.IsFalse(constraint.Check((string)null));
        }

        [Test]
        public void Check_WithNonNull_ExpectTrue()
        {
            var constraint = new NotNullConstraint();
            Assert.IsTrue(constraint.Check("Muttly"));
        }
    }
}