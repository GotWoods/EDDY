using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eddy.Core.Metadata;

/// <summary>
/// A metadata pack loaded from JSON. See docs/metadata-packs.md for the format.
/// Implements <see cref="IMetadataSource"/> for exactly one (standard, version).
/// </summary>
public class MetadataPack : IMetadataSource
{
    public const string FormatId = "eddy-metadata-pack/1";

    public string Name { get; set; }
    public string Standard { get; set; }
    public string Version { get; set; }
    public string Provenance { get; set; }
    public string License { get; set; }

    public Dictionary<string, DataElementDefinition> DataElements { get; } = new Dictionary<string, DataElementDefinition>();
    public Dictionary<string, SegmentDefinition> Segments { get; } = new Dictionary<string, SegmentDefinition>();
    public Dictionary<string, SegmentDefinition> Composites { get; } = new Dictionary<string, SegmentDefinition>();
    public Dictionary<string, Dictionary<string, string>> Codes { get; } = new Dictionary<string, Dictionary<string, string>>();

    public IReadOnlyList<KeyValuePair<string, string>> Versions =>
        new[] { new KeyValuePair<string, string>(Standard, Version) };

    private static readonly JsonSerializerOptions SaveOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public static MetadataPack Load(string path)
    {
        using (var stream = File.OpenRead(path))
            return Load(stream);
    }

    public static MetadataPack Load(Stream stream)
    {
        var dto = JsonSerializer.Deserialize<PackDto>(stream) ?? new PackDto();

        if (dto.format != FormatId)
            throw new InvalidDataException($"Unrecognised metadata pack format '{dto.format ?? "(missing)"}'; expected '{FormatId}'");

        var pack = new MetadataPack
        {
            Name = dto.name,
            Standard = dto.standard,
            Version = dto.version,
            Provenance = dto.provenance,
            License = dto.license,
        };

        if (dto.dataElements != null)
        {
            foreach (var kv in dto.dataElements)
            {
                ElementDataType type;
                int? decimals;
                ParseType(kv.Value?.type, out type, out decimals);
                pack.DataElements[kv.Key] = new DataElementDefinition
                {
                    Number = kv.Key,
                    Name = kv.Value?.name,
                    DataType = type,
                    Decimals = decimals,
                    MinLength = kv.Value?.min,
                    MaxLength = kv.Value?.max,
                };
            }
        }

        if (dto.composites != null)
            foreach (var kv in dto.composites)
                pack.Composites[kv.Key] = BuildRawSegment(kv.Key, kv.Value);

        if (dto.segments != null)
            foreach (var kv in dto.segments)
                pack.Segments[kv.Key] = BuildRawSegment(kv.Key, kv.Value);

        if (dto.codes != null)
            foreach (var kv in dto.codes)
                pack.Codes[kv.Key] = new Dictionary<string, string>(kv.Value);

        return pack;
    }

    public void Save(string path)
    {
        using (var stream = File.Create(path))
            Save(stream);
    }

    public void Save(Stream stream)
    {
        var dto = new PackDto
        {
            format = FormatId,
            standard = Standard,
            version = Version,
            name = Name,
            provenance = Provenance,
            license = License,
            dataElements = BuildDataElementDtos(),
            composites = BuildSegmentDtos(Composites),
            segments = BuildSegmentDtos(Segments),
            codes = BuildCodeDtos(),
        };

        JsonSerializer.Serialize(stream, dto, SaveOptions);
    }

    /// <summary>Copies everything from <paramref name="other"/> into this pack; other's values win on conflict.</summary>
    public void MergeFrom(MetadataPack other)
    {
        if (other == null)
            return;

        if (!string.IsNullOrEmpty(other.Name)) Name = other.Name;
        if (!string.IsNullOrEmpty(other.Standard)) Standard = other.Standard;
        if (!string.IsNullOrEmpty(other.Version)) Version = other.Version;
        if (!string.IsNullOrEmpty(other.Provenance)) Provenance = other.Provenance;
        if (!string.IsNullOrEmpty(other.License)) License = other.License;

        foreach (var kv in other.DataElements)
            DataElements[kv.Key] = kv.Value;

        foreach (var kv in other.Composites)
            Composites[kv.Key] = kv.Value;

        foreach (var kv in other.Segments)
            Segments[kv.Key] = kv.Value;

        foreach (var kv in other.Codes)
        {
            Dictionary<string, string> existing;
            if (!Codes.TryGetValue(kv.Key, out existing))
            {
                existing = new Dictionary<string, string>();
                Codes[kv.Key] = existing;
            }
            foreach (var code in kv.Value)
                existing[code.Key] = code.Value;
        }
    }

    public SegmentDefinition GetSegment(string standard, string version, string id)
    {
        if (!Matches(standard, version) || id == null)
            return null;

        SegmentDefinition raw;
        if (Segments.TryGetValue(id, out raw))
            return Resolve(raw, new HashSet<string>());
        if (Composites.TryGetValue(id, out raw))
            return Resolve(raw, new HashSet<string>());
        return null;
    }

    public DataElementDefinition GetDataElement(string standard, string version, string dataElementNumber)
    {
        if (!Matches(standard, version) || dataElementNumber == null)
            return null;

        DataElementDefinition de;
        return DataElements.TryGetValue(dataElementNumber, out de) ? de : null;
    }

    public IReadOnlyDictionary<string, string> GetCodes(string standard, string version, string dataElementNumber)
    {
        if (!Matches(standard, version) || dataElementNumber == null)
            return null;

        Dictionary<string, string> codes;
        return Codes.TryGetValue(dataElementNumber, out codes) ? codes : null;
    }

    private bool Matches(string standard, string version)
    {
        return string.Equals(Standard, standard, StringComparison.Ordinal)
               && string.Equals(Version, version, StringComparison.Ordinal);
    }

    /// <summary>Resolves a raw (pos/de-or-composite/req only) segment into a fully described one, following
    /// composite references recursively. <paramref name="visiting"/> guards against cycles.</summary>
    private SegmentDefinition Resolve(SegmentDefinition raw, HashSet<string> visiting)
    {
        var result = new SegmentDefinition
        {
            Standard = Standard,
            Version = Version,
            Id = raw.Id,
            Name = raw.Name,
            Origin = Name,
        };

        foreach (var e in raw.Elements)
            result.Elements.Add(ResolveElement(e, raw.Id, visiting));

        return result;
    }

    private ElementDefinition ResolveElement(ElementDefinition raw, string parentId, HashSet<string> visiting)
    {
        var elem = new ElementDefinition
        {
            Position = raw.Position,
            Reference = parentId + raw.Position.ToString("D2"),
            Requirement = raw.Requirement,
            Origin = Name,
        };

        if (!string.IsNullOrEmpty(raw.CompositeId))
        {
            elem.CompositeId = raw.CompositeId;
            elem.DataType = ElementDataType.Composite;

            SegmentDefinition compositeDef;
            if (Composites.TryGetValue(raw.CompositeId, out compositeDef) && visiting.Add(raw.CompositeId))
            {
                elem.Name = compositeDef.Name;
                foreach (var ce in compositeDef.Elements)
                    elem.Components.Add(ResolveElement(ce, raw.CompositeId, visiting));
                visiting.Remove(raw.CompositeId);
            }
        }
        else if (!string.IsNullOrEmpty(raw.DataElementNumber))
        {
            elem.DataElementNumber = raw.DataElementNumber;

            DataElementDefinition de;
            if (DataElements.TryGetValue(raw.DataElementNumber, out de))
            {
                elem.Name = de.Name;
                elem.DataType = de.DataType;
                elem.Decimals = de.Decimals;
                elem.MinLength = de.MinLength;
                elem.MaxLength = de.MaxLength;
            }

            if (elem.DataType == ElementDataType.Identifier || Codes.ContainsKey(raw.DataElementNumber))
                elem.CodeListId = raw.DataElementNumber;
        }

        return elem;
    }

    private static SegmentDefinition BuildRawSegment(string id, SegmentDto dto)
    {
        var def = new SegmentDefinition { Id = id, Name = dto?.name };
        if (dto?.elements != null)
        {
            foreach (var e in dto.elements)
            {
                def.Elements.Add(new ElementDefinition
                {
                    Position = e.pos,
                    DataElementNumber = e.de,
                    CompositeId = e.composite,
                    Requirement = ParseRequirement(e.req),
                });
            }
        }
        return def;
    }

    private Dictionary<string, DataElementDto> BuildDataElementDtos()
    {
        if (DataElements.Count == 0)
            return null;

        var result = new SortedDictionary<string, DataElementDto>(StringComparer.Ordinal);
        foreach (var kv in DataElements)
        {
            var de = kv.Value;
            result[kv.Key] = new DataElementDto
            {
                name = de.Name,
                type = FormatType(de.DataType, de.Decimals),
                min = de.MinLength,
                max = de.MaxLength,
            };
        }
        return new Dictionary<string, DataElementDto>(result);
    }

    private Dictionary<string, SegmentDto> BuildSegmentDtos(Dictionary<string, SegmentDefinition> source)
    {
        if (source.Count == 0)
            return null;

        var result = new SortedDictionary<string, SegmentDto>(StringComparer.Ordinal);
        foreach (var kv in source)
        {
            var seg = kv.Value;
            var dto = new SegmentDto { name = seg.Name };
            if (seg.Elements.Count > 0)
            {
                dto.elements = seg.Elements
                    .OrderBy(e => e.Position)
                    .Select(e => new ElementRefDto
                    {
                        pos = e.Position,
                        de = e.DataElementNumber,
                        composite = e.CompositeId,
                        req = FormatRequirement(e.Requirement),
                    })
                    .ToList();
            }
            result[kv.Key] = dto;
        }
        return new Dictionary<string, SegmentDto>(result);
    }

    private Dictionary<string, Dictionary<string, string>> BuildCodeDtos()
    {
        if (Codes.Count == 0)
            return null;

        var result = new SortedDictionary<string, Dictionary<string, string>>(StringComparer.Ordinal);
        foreach (var kv in Codes)
        {
            var inner = new SortedDictionary<string, string>(kv.Value, StringComparer.Ordinal);
            result[kv.Key] = new Dictionary<string, string>(inner);
        }
        return new Dictionary<string, Dictionary<string, string>>(result);
    }

    private static void ParseType(string raw, out ElementDataType type, out int? decimals)
    {
        type = ElementDataType.Unknown;
        decimals = null;

        if (string.IsNullOrEmpty(raw))
            return;

        switch (raw)
        {
            case "ID":
                type = ElementDataType.Identifier;
                return;
            case "AN":
                type = ElementDataType.AlphaNumeric;
                return;
            case "R":
                type = ElementDataType.Decimal;
                return;
            case "DT":
                type = ElementDataType.Date;
                return;
            case "TM":
                type = ElementDataType.Time;
                return;
            case "B":
                type = ElementDataType.Binary;
                return;
            case "N":
                type = ElementDataType.Numeric;
                decimals = 0;
                return;
            default:
                if (raw.Length == 2 && raw[0] == 'N' && char.IsDigit(raw[1]))
                {
                    type = ElementDataType.Numeric;
                    decimals = raw[1] - '0';
                }
                return;
        }
    }

    private static string FormatType(ElementDataType type, int? decimals)
    {
        switch (type)
        {
            case ElementDataType.Identifier: return "ID";
            case ElementDataType.AlphaNumeric: return "AN";
            case ElementDataType.Numeric: return decimals.HasValue && decimals.Value != 0 ? "N" + decimals.Value : "N";
            case ElementDataType.Decimal: return "R";
            case ElementDataType.Date: return "DT";
            case ElementDataType.Time: return "TM";
            case ElementDataType.Binary: return "B";
            default: return null;
        }
    }

    private static Requirement ParseRequirement(string s)
    {
        switch (s)
        {
            case "M": return Requirement.Mandatory;
            case "O": return Requirement.Optional;
            case "C": return Requirement.Conditional;
            default: return Requirement.Unknown;
        }
    }

    private static string FormatRequirement(Requirement r)
    {
        switch (r)
        {
            case Requirement.Mandatory: return "M";
            case Requirement.Optional: return "O";
            case Requirement.Conditional: return "C";
            default: return null;
        }
    }

    private class PackDto
    {
        public string format { get; set; }
        public string standard { get; set; }
        public string version { get; set; }
        public string name { get; set; }
        public string provenance { get; set; }
        public string license { get; set; }
        public Dictionary<string, DataElementDto> dataElements { get; set; }
        public Dictionary<string, SegmentDto> composites { get; set; }
        public Dictionary<string, SegmentDto> segments { get; set; }
        public Dictionary<string, Dictionary<string, string>> codes { get; set; }
    }

    private class DataElementDto
    {
        public string name { get; set; }
        public string type { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
    }

    private class SegmentDto
    {
        public string name { get; set; }
        public List<ElementRefDto> elements { get; set; }
    }

    private class ElementRefDto
    {
        public int pos { get; set; }
        public string de { get; set; }
        public string composite { get; set; }
        public string req { get; set; }
    }
}
