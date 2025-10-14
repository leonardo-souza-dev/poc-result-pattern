using Microsoft.AspNetCore.Mvc;

namespace TheLibrary;

public class ResultStatusMapper
{
    private readonly Dictionary<string, Type> _options = [];

    public static ResultStatusMapper Build()
    {
        return new ResultStatusMapper();
    }

    public ResultStatusMapper Add(string resultStatus, Type type)
    {
        _options[resultStatus] = type;
        return this;
    }

    public Dictionary<string, Type> GetDictionary()
    {
        return _options;
    }
}
