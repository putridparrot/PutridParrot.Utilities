namespace PutridParrot.Utilities
{
    public class NullConstraint : IConstraint
    {
        public bool Check<T>(T value)
        {
            return value == null;
        }
    }
}