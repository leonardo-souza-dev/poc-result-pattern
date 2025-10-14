using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace TheLibrary;

public static class WebApplicationExtensions
{
    private static Dictionary<string, Type>? _dict;
    
    public static IApplicationBuilder UseStandardResultPattern(this IApplicationBuilder applicationBuilder, ResultStatusMapper mapper)
    {
        _dict = mapper.GetDictionary();
        return applicationBuilder;
    }

    public static Dictionary<string, Type>? GetResulStatusMapper()
    {
        return _dict;
    }
}

