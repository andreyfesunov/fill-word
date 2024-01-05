namespace game_center_backend_cs.Infrastructure.Utils;

[AttributeUsage(AttributeTargets.Class)]
public class CollectionNameAttribute : Attribute
{
    public CollectionNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}