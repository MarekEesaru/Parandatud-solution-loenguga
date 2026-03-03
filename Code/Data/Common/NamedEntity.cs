namespace Abc.Data.Common;

public abstract class NamedEntity: DetailedEntity
{
    public string Name { get; set; } = "";
    public string code { get; set; } = "";
}
