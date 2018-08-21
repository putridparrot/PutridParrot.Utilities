namespace PutridParrot.Utilities
{
    /// <summary>
    /// Condition is a class designed for pre-condition tests
    /// etc. Partly inspired by NUnit's constraint style tests
    /// </summary>
    public static partial class Condition
    {
        public static void Check<T>(T value, IConstraint condition, string message = null)
        {
            if (!condition.Check(value))
            {
                throw new ConditionException(message);
            }
        }

        public static void Check<T>(T value, ConstraintExpression expression, string message = null)
        {
            if (!expression.Check(value))
            {
                throw new ConditionException(message);
            }
        }
    }

}
