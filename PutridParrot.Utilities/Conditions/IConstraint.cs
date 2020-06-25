namespace PutridParrot.Utilities
{
    public interface IConstraint
    {
        bool Check<T>(T value);
    }
}