namespace CSharp11.CS11;

public record class RequiredMember1
{
    public required int? Prop1 { get; init; }
    public required int? Prop2 { get; set; }
}

public record class RequiredMember2
{
    public required int? Prop1 { get; init; }
    public required int? Prop2 { get; set; }

    public RequiredMember2(int? prop1 = null, int? prop2 = null)
    {
        Prop1 = prop1;
        Prop2 = prop2;
    }
}

public record class RequiredMember3
{
    public required int? Prop1 { get; init; }
    public required int? Prop2 { get; set; }

    public RequiredMember3(int? prop1, int? prop2)
    {
        Prop1 = prop1;
        Prop2 = prop2;
    }
}

public record class SubRequiredMember1: RequiredMember1
{
    public required int? Prop3 { get; init; }
    public required int? Prop4 { get; set; }
}

public record class NonRequiredMember1
{
    public int? Prop1 { get; init; }
    public int? Prop2 { get; set; }
}

public record class NonRequiredMember2
{
    public int? Prop1 { get; init; }
    public int? Prop2 { get; set; }

    public NonRequiredMember2(int? prop1 = null, int? prop2 = null)
    {
        Prop1 = prop1;
        Prop2 = prop2;
    }
}

public record class NonRequiredMember3
{
    public int? Prop1 { get; init; }
    public int? Prop2 { get; set; }

    public NonRequiredMember3(int? prop1, int? prop2)
    {
        Prop1 = prop1;
        Prop2 = prop2;
    }
}
