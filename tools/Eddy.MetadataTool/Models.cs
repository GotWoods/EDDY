namespace Eddy.MetadataTool;

/// <summary>One element position inside a segment or composite: <see cref="De"/> or
/// <see cref="Composite"/> is set (never both), per the metadata pack format.</summary>
public sealed class ElementRef
{
    public int Pos { get; set; }
    public string? De { get; set; }
    public string? Composite { get; set; }
    public string? Req { get; set; }
}

public sealed class DataElementDef
{
    public string? Name { get; set; }
    public string Type { get; set; } = "";
    public int? Min { get; set; }
    public int? Max { get; set; }

    public bool StructurallyEquals(DataElementDef other) =>
        Type == other.Type && Min == other.Min && Max == other.Max;
}

/// <summary>A composite or segment: a name plus an ordered list of element positions.</summary>
public sealed class ComponentDef
{
    public string? Name { get; set; }
    public List<ElementRef> Elements { get; set; } = new();

    public bool StructurallyEquals(ComponentDef other)
    {
        if (Elements.Count != other.Elements.Count) return false;
        var a = Elements.OrderBy(e => e.Pos).ToList();
        var b = other.Elements.OrderBy(e => e.Pos).ToList();
        for (var i = 0; i < a.Count; i++)
        {
            if (a[i].Pos != b[i].Pos || a[i].De != b[i].De || a[i].Composite != b[i].Composite || a[i].Req != b[i].Req)
                return false;
        }
        return true;
    }
}

public sealed class MetadataPackModel
{
    public string Format { get; set; } = "eddy-metadata-pack/1";
    public string Standard { get; set; } = "";
    public string Version { get; set; } = "";
    public string? Name { get; set; }
    public string? Provenance { get; set; }
    public string? License { get; set; }

    public Dictionary<string, DataElementDef> DataElements { get; } = new();
    public Dictionary<string, ComponentDef> Composites { get; } = new();
    public Dictionary<string, ComponentDef> Segments { get; } = new();
    public Dictionary<string, Dictionary<string, string>> Codes { get; } = new();
}
