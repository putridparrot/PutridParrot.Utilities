using System.Collections.Generic;

namespace PutridParrot.Utilities
{
    public class ConstraintExpression : IConstraint
    {
        private readonly Stack<IConstraint> _constraints =
            new Stack<IConstraint>();

        private ConstraintExpression Chain(IConstraint constraint)
        {
            _constraints.Push(constraint);
            return this;
        }

        public bool Check<T>(T value)
        {
            var current = _constraints.Pop().Check(value);
            while (_constraints.Count > 0)
            {
                current = _constraints.Pop().Check(current);
            }
            return current;
        }

        public ConstraintExpression Not => Chain(new NotConstraint());
        public ConstraintExpression Null => Chain(new NullConstraint());
    }

}
