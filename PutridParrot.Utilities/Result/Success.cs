namespace PutridParrot.Utilities;

public class Success : ISuccess
{
}

public class Success<T> : Success, ISuccess<T>
{
    public Success(T value)
    {
        Value = value;
    }

    public T Value { get; }
}