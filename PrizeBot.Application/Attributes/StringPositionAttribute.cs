namespace PrizeBot.Application.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class StringPositionAttribute : Attribute
{
    public int Position { get; }

    public StringPositionAttribute(int position)
    {
        Position = position;
    }
}