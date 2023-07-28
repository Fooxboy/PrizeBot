namespace PrizeBot.Application.Helpers;

public class SimpleMapper
{
    public static T Map<T>(object source) where T : new()
    {
        T target = new T();

        var sourceProperties = source.GetType().GetProperties();
        var targetProperties = typeof(T).GetProperties();

        foreach (var sourceProp in sourceProperties)
        {
            var targetProp = targetProperties.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);

            if (targetProp != null && targetProp.CanWrite)
            {
                var value = sourceProp.GetValue(source);
                targetProp.SetValue(target, value);
            }
        }

        return target;
    }
}