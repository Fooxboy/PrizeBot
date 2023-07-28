using System.Reflection;
using PrizeBot.Application.Attributes;

namespace PrizeBot.Application.Helpers;

public static class ArgumentsParser
{
    public static TModel Parse<TModel>(string text, string separator = " ") where TModel : new()
    {
        var model = new TModel();

        var props = typeof(TModel).GetProperties();

        var args = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        foreach (var prop in props)
        {
            var attr = prop.GetCustomAttribute<StringPositionAttribute>();
            
            if(attr == null || attr.Position >= args.Length) continue;

            var value = Convert.ChangeType(args[attr.Position], prop.PropertyType);
            
            prop.SetValue(model, value);
        }

        return model;
    }
}