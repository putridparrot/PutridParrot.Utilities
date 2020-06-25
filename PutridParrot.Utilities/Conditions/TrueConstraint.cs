namespace PutridParrot.Utilities
{
    public class TrueConstraint : IConstraint
    {
        public bool Check<T>(T value)
        {
            return true.Equals(value);
        }
    }
}