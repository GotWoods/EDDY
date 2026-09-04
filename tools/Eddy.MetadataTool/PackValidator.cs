namespace Eddy.MetadataTool;

public sealed class ValidationResult
{
    public List<string> Problems { get; } = new();
    public int SegmentCount { get; set; }
    public int CompositeCount { get; set; }
    public int DataElementCount { get; set; }
    public int CodeListCount { get; set; }
    public int CodeCount { get; set; }

    public bool IsValid => Problems.Count == 0;
}

/// <summary>Validates a metadata pack: required top-level fields, that every segment/composite
/// element has exactly one of de/composite and that it resolves, and that positions are positive
/// and unique within their owning segment or composite.</summary>
public static class PackValidator
{
    private static readonly HashSet<string> ValidStandards = new(StringComparer.Ordinal) { "X12", "EDIFACT" };

    public static ValidationResult Validate(MetadataPackModel pack)
    {
        var result = new ValidationResult
        {
            SegmentCount = pack.Segments.Count,
            CompositeCount = pack.Composites.Count,
            DataElementCount = pack.DataElements.Count,
            CodeListCount = pack.Codes.Count,
            CodeCount = pack.Codes.Values.Sum(m => m.Count),
        };

        if (pack.Format != "eddy-metadata-pack/1")
            result.Problems.Add($"unexpected format '{pack.Format}' (expected 'eddy-metadata-pack/1')");

        if (!ValidStandards.Contains(pack.Standard))
            result.Problems.Add($"unexpected standard '{pack.Standard}' (expected X12 or EDIFACT)");

        if (string.IsNullOrWhiteSpace(pack.Version))
            result.Problems.Add("version is missing or empty");

        ValidateComponents(pack, pack.Segments, "segment", result);
        ValidateComponents(pack, pack.Composites, "composite", result);

        return result;
    }

    private static void ValidateComponents(MetadataPackModel pack, Dictionary<string, ComponentDef> components, string kind, ValidationResult result)
    {
        foreach (var (ownerKey, component) in components)
        {
            var seenPositions = new HashSet<int>();
            foreach (var element in component.Elements)
            {
                var hasDe = element.De is not null;
                var hasComposite = element.Composite is not null;
                if (hasDe == hasComposite)
                    result.Problems.Add($"{kind} {ownerKey} pos {element.Pos}: must have exactly one of de/composite");

                if (hasDe && !pack.DataElements.ContainsKey(element.De!))
                    result.Problems.Add($"{kind} {ownerKey} pos {element.Pos}: data element '{element.De}' does not resolve");

                if (hasComposite && !pack.Composites.ContainsKey(element.Composite!))
                    result.Problems.Add($"{kind} {ownerKey} pos {element.Pos}: composite '{element.Composite}' does not resolve");

                if (element.Pos <= 0)
                    result.Problems.Add($"{kind} {ownerKey}: position {element.Pos} is not positive");
                else if (!seenPositions.Add(element.Pos))
                    result.Problems.Add($"{kind} {ownerKey}: duplicate position {element.Pos}");
            }
        }
    }
}
