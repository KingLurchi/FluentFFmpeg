namespace FluentFFmpeg.Core.Models;

public class Size<T> where T : struct
{
    public Size(T value, string unit)
    {
        Value = value;
        Unit = unit;
    }

    public T Value { get; }
    public string Unit { get; }

    public override string ToString() => $"{Value}{Unit}";
}