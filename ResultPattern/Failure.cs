namespace ResultPattern;

public sealed class Failure
{
    public string Code { get; private set; }
    public string Message { get; private set; }

    public bool IsCode(string code)
    {
        return this.Code.Equals(code);
    }

    public static Failure Of(string code, string message)
    {
        return new Failure
        {
            Code = code,
            Message = message
        };
    }
}