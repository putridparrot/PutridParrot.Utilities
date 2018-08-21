namespace PutridParrot.Utilities
{
    public class NotNullConstraint : IConstraint
    {
        public bool Check<T>(T value)
        {
            return value != null;
        }
    }
}