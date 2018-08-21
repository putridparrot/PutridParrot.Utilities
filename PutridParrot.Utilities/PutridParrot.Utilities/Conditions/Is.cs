using System.Collections.Generic;
using System.Text;

namespace PutridParrot.Utilities
{
    public abstract class Is
    {
        public static NotNullConstraint NotNull => new NotNullConstraint();
        public static NullConstraint Null => new NullConstraint();
        public static TrueConstraint True => new TrueConstraint();
        public static FalseConstraint False => new FalseConstraint();

        public static ConstraintExpression Not => new ConstraintExpression().Not;
    }
}
