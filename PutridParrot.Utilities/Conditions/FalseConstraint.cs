namespace PutridParrot.Utilities
{
    public class FalseConstraint : IConstraint
    {
        public bool Check<T>(T value)
        {
            return false.Equals(value);
        }
    }
}