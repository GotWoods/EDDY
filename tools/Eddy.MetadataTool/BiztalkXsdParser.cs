using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Eddy.MetadataTool;

/// <summary>What one EFACT_*.xsd file contributed: segments, composites, the data elements they
/// reference and the codes for any ID-typed data element, plus warnings for anything that could
/// not be mapped.</summary>
public sealed class BiztalkFileImport
{
    public Dictionary<string, DataElementDef> DataElements { get; } = new();
    public Dictionary<string, ComponentDef> Composites { get; } = new();
    public Dictionary<string, ComponentDef> Segments { get; } = new();
    public Dictionary<string, Dictionary<string, string>> Codes { get; } = new();
    public List<string> Warnings { get; } = new();
}

/// <summary>Parses one Microsoft BizTalk EDIFACT schema (EFACT_&lt;version&gt;_&lt;MESSAGE&gt;.xsd)
/// into segment, composite, data element and code definitions. See the class comment in
/// docs/metadata-packs.md and the task notes for the BizTalk conventions this relies on:
/// segments and composites are top-level xs:element definitions named with the EDIFACT tag
/// (optionally suffixed "_2", "_3", ... when BizTalk needs a second, structurally identical,
/// global element for the same tag); fields carry their data element number as the suffix of
/// their b:fieldInfo/@notes ("Party qualifier_3035"); ID-typed fields reference a named
/// EDIFACT_ID_&lt;number&gt; simple type whose enumeration values are the valid codes.</summary>
public static class BiztalkXsdParser
{
    private static readonly XNamespace Xs = "http://www.w3.org/2001/XMLSchema";
    private static readonly XNamespace B = "http://schemas.microsoft.com/BizTalk/2003";

    private static readonly HashSet<string> EnvelopeSegments = new(StringComparer.Ordinal)
    {
        "UNA", "UNB", "UNH", "UNT", "UNZ",
    };

    private static readonly Regex SuffixPattern = new(@"_\d+$", RegexOptions.Compiled);
    private static readonly Regex SegmentTag = new(@"^[A-Z]{3}$", RegexOptions.Compiled);
    private static readonly Regex CompositeTag = new(@"^C\d{3}$", RegexOptions.Compiled);
    private static readonly Regex FieldNotesPattern = new(@"^(.*)_(\d+)$", RegexOptions.Compiled);
    private static readonly Regex IdTypePattern = new(@"^EDIFACT_ID_(\d+)$", RegexOptions.Compiled);

    public static BiztalkFileImport Parse(string path)
    {
        var doc = XDocument.Load(path);
        var root = doc.Root ?? throw new FormatException($"{path}: no root element");
        var result = new BiztalkFileImport();

        var idTypeCodes = CollectIdTypeCodes(root);

        foreach (var topElement in root.Elements(Xs + "element"))
        {
            var rawName = topElement.Attribute("name")?.Value;
            if (rawName is null) continue;

            var baseName = StripCloneSuffix(rawName);
            if (EnvelopeSegments.Contains(baseName)) continue;

            if (SegmentTag.IsMatch(baseName))
            {
                if (result.Segments.ContainsKey(baseName)) continue; // identical BizTalk clone within the same file
                var elements = ParseElementSequence(topElement, result, idTypeCodes);
                result.Segments[baseName] = new ComponentDef { Name = TitleCaseOrNull(GetOwnNotes(topElement, "recordInfo")), Elements = elements };
            }
            else if (CompositeTag.IsMatch(baseName))
            {
                if (result.Composites.ContainsKey(baseName)) continue;
                var elements = ParseElementSequence(topElement, result, idTypeCodes);
                result.Composites[baseName] = new ComponentDef { Name = TitleCaseOrNull(GetOwnNotes(topElement, "recordInfo")), Elements = elements };
            }
            // else: message envelope root, or a "<Tag>Loop<N>" structural grouping - not a real EDIFACT construct.
        }

        return result;
    }

    private static Dictionary<string, List<string>> CollectIdTypeCodes(XElement root)
    {
        var map = new Dictionary<string, List<string>>();
        foreach (var simpleType in root.Elements(Xs + "simpleType"))
        {
            var name = simpleType.Attribute("name")?.Value;
            if (name is null) continue;
            var match = IdTypePattern.Match(name);
            if (!match.Success) continue;

            var restriction = simpleType.Element(Xs + "restriction");
            var values = restriction?.Elements(Xs + "enumeration")
                .Select(e => e.Attribute("value")?.Value)
                .Where(v => v is not null)
                .Select(v => v!)
                .ToList() ?? new List<string>();
            map[match.Groups[1].Value] = values;
        }
        return map;
    }

    private static List<ElementRef> ParseElementSequence(XElement owner, BiztalkFileImport result, Dictionary<string, List<string>> idTypeCodes)
    {
        var refs = new List<ElementRef>();
        var sequence = owner.Element(Xs + "complexType")?.Element(Xs + "sequence");
        if (sequence is null) return refs;

        var pos = 1;
        foreach (var child in sequence.Elements(Xs + "element"))
        {
            var req = child.Attribute("minOccurs")?.Value == "0" ? "C" : "M";
            var refAttr = child.Attribute("ref")?.Value;

            if (refAttr is not null)
            {
                refs.Add(new ElementRef { Pos = pos, Composite = StripCloneSuffix(refAttr), Req = req });
                pos++;
                continue;
            }

            var fieldName = child.Attribute("name")?.Value ?? "(unnamed)";
            var field = ParseField(child, fieldName, idTypeCodes, result);
            if (field is null)
            {
                // Warning already recorded by ParseField; the field cannot be mapped to a data
                // element number so it is left out - it keeps whatever derived metadata Eddy.Core
                // computes for that position.
                pos++;
                continue;
            }

            if (!result.DataElements.ContainsKey(field.DeNumber))
                result.DataElements[field.DeNumber] = field.Definition;

            refs.Add(new ElementRef { Pos = pos, De = field.DeNumber, Req = req });
            pos++;
        }

        return refs;
    }

    private sealed record ParsedField(string DeNumber, DataElementDef Definition);

    private static ParsedField? ParseField(XElement field, string fieldName, Dictionary<string, List<string>> idTypeCodes, BiztalkFileImport result)
    {
        var notes = GetOwnNotes(field, "fieldInfo");
        var notesMatch = notes is not null ? FieldNotesPattern.Match(notes) : null;
        var deName = notesMatch is { Success: true } m ? m.Groups[1].Value.Trim() : null;

        var typeAttr = field.Attribute("type")?.Value;
        if (typeAttr is not null)
        {
            var idMatch = IdTypePattern.Match(typeAttr);
            if (!idMatch.Success)
            {
                result.Warnings.Add($"field {fieldName} has unrecognized type attribute '{typeAttr}'; skipped");
                return null;
            }

            var deNumber = idMatch.Groups[1].Value;
            int? min = null, max = null;
            if (idTypeCodes.TryGetValue(deNumber, out var values) && values.Count > 0)
            {
                min = 1;
                max = values.Max(v => v.Length);
                if (!result.Codes.TryGetValue(deNumber, out var codeMap))
                    result.Codes[deNumber] = codeMap = new Dictionary<string, string>();
                foreach (var value in values)
                    codeMap.TryAdd(value, "");
            }

            return new ParsedField(deNumber, new DataElementDef { Name = deName, Type = "ID", Min = min, Max = max });
        }

        var restriction = field.Element(Xs + "simpleType")?.Element(Xs + "restriction");
        var baseAttr = restriction?.Attribute("base")?.Value;
        var type = baseAttr switch
        {
            "EDIFACT_N" => "N",
            "EDIFACT_AN" => "AN",
            "EDIFACT_A" => "AN",
            _ => (string?)null,
        };
        if (type is null)
        {
            result.Warnings.Add($"field {fieldName} has unrecognized base type '{baseAttr}'; skipped");
            return null;
        }

        int? fMin = null, fMax = null;
        var lengthEl = restriction?.Element(Xs + "length");
        if (lengthEl?.Attribute("value")?.Value is { } lengthValue && int.TryParse(lengthValue, out var len))
        {
            fMin = len;
            fMax = len;
        }
        else
        {
            if (restriction?.Element(Xs + "minLength")?.Attribute("value")?.Value is { } minValue && int.TryParse(minValue, out var min2))
                fMin = min2;
            if (restriction?.Element(Xs + "maxLength")?.Attribute("value")?.Value is { } maxValue && int.TryParse(maxValue, out var max2))
                fMax = max2;
        }

        if (notesMatch is not { Success: true })
        {
            result.Warnings.Add($"field {fieldName} has no data element number in its notes ('{notes}'); skipped");
            return null;
        }

        return new ParsedField(notesMatch.Groups[2].Value, new DataElementDef { Name = deName, Type = type, Min = fMin, Max = fMax });
    }

    private static string? GetOwnNotes(XElement element, string infoElementName) =>
        element.Element(Xs + "annotation")?.Element(Xs + "appinfo")?.Element(B + infoElementName)?.Attribute("notes")?.Value;

    private static string StripCloneSuffix(string name) => SuffixPattern.Replace(name, "");

    private static string? TitleCaseOrNull(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return null;
        var words = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(' ', words.Select(w => char.ToUpperInvariant(w[0]) + w[1..].ToLowerInvariant()));
    }
}
