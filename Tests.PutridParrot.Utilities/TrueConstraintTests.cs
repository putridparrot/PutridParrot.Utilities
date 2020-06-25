using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class TrueConstraintTests
    {
        [Test]
        public void Check_WithFalse_ExpectFalse()
        {
            var constraint = new TrueConstraint();
            Assert.IsFalse(constraint.Check(false));
        }

        [Test]
        public void Check_WithTrue_ExpectTrue()
        {
            var constraint = new TrueConstraint();
            Assert.IsTrue(constraint.Check(true));
        }
    }
}