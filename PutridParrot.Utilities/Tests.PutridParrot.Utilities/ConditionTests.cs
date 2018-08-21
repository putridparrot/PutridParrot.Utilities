using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ConditionTests
    {
        public class SuccessConstraint : IConstraint
        {
            public bool Check<T>(T value)
            {
                return true;
            }
        }

        public class FailureConstraint : IConstraint
        {
            public bool Check<T>(T value)
            {
                return false;
            }
        }

        [Test]
        public void Check_SuccesfullConstraint_ExpectNoException()
        {
            Condition.Check(123, new SuccessConstraint());
        }

        [Test]
        public void Check_FailureConstraint_ExpectException()
        {
            Assert.Throws<ConditionException>(() => Condition.Check(123, new FailureConstraint()));
        }
    }
}
