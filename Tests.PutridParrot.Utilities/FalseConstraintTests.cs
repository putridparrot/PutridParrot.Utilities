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
    public class FalseConstraintTests
    {
        [Test]
        public void Check_WithFalse_ExpectTrue()
        {
            var constraint = new FalseConstraint();
            Assert.IsTrue(constraint.Check(false));
        }

        [Test]
        public void Check_WithTrue_ExpectFalse()
        {
            var constraint = new FalseConstraint();
            Assert.IsFalse(constraint.Check(true));
        }
    }
}
