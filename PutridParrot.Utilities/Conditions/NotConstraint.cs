namespace PutridParrot.Utilities
{
    public class NotConstraint : IConstraint
    {
        public bool Check<T>(T value)
        {
            return !true.Equals(value);
        }
    }
}