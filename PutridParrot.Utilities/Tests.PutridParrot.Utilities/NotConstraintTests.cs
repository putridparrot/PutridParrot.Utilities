using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class NotConstraintTests
    {
        [Test]
        public void Check_WithFalse_ExpectTrue()
        {
            var constraint = new NotConstraint();
            Assert.IsTrue(constraint.Check(false));
        }

        [Test]
        public void Check_WithTrue_ExpectFalse()
        {
            var constraint = new NotConstraint();
            Assert.IsFalse(constraint.Check(true));
        }
    }
}