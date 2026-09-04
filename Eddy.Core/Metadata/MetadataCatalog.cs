using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eddy.Core.Metadata;

/// <summary>
/// Combines derived metadata with any number of packs. Thread-safe. Describe() results are cached per
/// type and invalidated when a source is added.
/// </summary>
public class MetadataCatalog
{
    /// <summary>A process-wide catalog for callers that do not manage their own.</summary>
    public static MetadataCatalog Default { get; } = new MetadataCatalog();

    private readonly object _lock = new object();
    private volatile List<IMetadataSource> _sources = new List<IMetadataSource>();
    private volatile ConcurrentDictionary<Type, SegmentDefinition> _describeCache = new ConcurrentDictionary<Type, SegmentDefinition>();

    public IReadOnlyList<IMetadataSource> Sources
    {
        get { return _sources; }
    }

    public void AddSource(IMetadataSource source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        lock (_lock)
        {
            var next = new List<IMetadataSource>(_sources) { source };
            _sources = next;
        }

        // later sources overlay earlier ones; invalidate anything already computed.
        _describeCache = new ConcurrentDictionary<Type, SegmentDefinition>();
    }

    public void AddPack(MetadataPack pack) => AddSource(pack);

    /// <summary>Loads every *.json file in the directory as a pack; files that are not packs are skipped and reported in the return value.</summary>
    public IReadOnlyList<string> AddPacksFromDirectory(string directory)
    {
        var skipped = new List<string>();
        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => Path.GetFileName(f), StringComparer.Ordinal);

        foreach (var file in files)
        {
            try
            {
                var pack = MetadataPack.Load(file);
                AddSource(pack);
            }
            catch (Exception ex)
            {
                skipped.Add($"{Path.GetFileName(file)}: {ex.Message}");
            }
        }

        return skipped;
    }

    /// <summary>Derived metadata for the type, overlaid with every matching pack. Never null for a type with [Position] properties.</summary>
    public SegmentDefinition Describe(Type segmentType)
    {
        if (segmentType == null)
            throw new ArgumentNullException(nameof(segmentType));

        var cache = _describeCache;
        SegmentDefinition cached;
        if (cache.TryGetValue(segmentType, out cached))
            return cached.Clone();

        var derived = DerivedSegmentMetadata.Describe(segmentType);
        OverlayWithSources(derived);

        cache[segmentType] = derived;
        return derived.Clone();
    }

    /// <summary>Pack definition for a segment identifier without a model type, or null when no pack has it.</summary>
    public SegmentDefinition GetSegment(string standard, string version, string id)
    {
        var normalized = NormalizeVersion(standard, version);
        foreach (var source in LastAddedFirst())
        {
            var chosen = PickVersion(source, standard, normalized);
            if (chosen == null)
                continue;
            var result = source.GetSegment(standard, chosen, id);
            if (result != null)
                return result;
        }
        return null;
    }

    public DataElementDefinition GetDataElement(string standard, string version, string dataElementNumber)
    {
        var normalized = NormalizeVersion(standard, version);
        foreach (var source in LastAddedFirst())
        {
            var chosen = PickVersion(source, standard, normalized);
            if (chosen == null)
                continue;
            var result = source.GetDataElement(standard, chosen, dataElementNumber);
            if (result != null)
                return result;
        }
        return null;
    }

    /// <summary>Description of a code value for a data element, or null when no loaded pack knows it.</summary>
    public string DescribeCode(string standard, string version, string dataElementNumber, string code)
    {
        var codes = GetCodes(standard, version, dataElementNumber);
        if (codes == null)
            return null;

        string description;
        return codes.TryGetValue(code, out description) ? description : null;
    }

    public IReadOnlyDictionary<string, string> GetCodes(string standard, string version, string dataElementNumber)
    {
        var normalized = NormalizeVersion(standard, version);
        foreach (var source in LastAddedFirst())
        {
            var chosen = PickVersion(source, standard, normalized);
            if (chosen == null)
                continue;
            var result = source.GetCodes(standard, chosen, dataElementNumber);
            if (result != null)
                return result;
        }
        return null;
    }

    /// <summary>"4010", "00401" and "004010" all become "004010"; EDIFACT versions are upper-cased ("d96a" to "D96A").</summary>
    public static string NormalizeVersion(string standard, string version)
    {
        if (version == null)
            return null;

        if (standard == "X12")
        {
            if (version.Length == 4)
                return "00" + version;
            if (version.Length == 5)
                return version + "0";
            if (version.Length == 6)
                return version;
            if (version.Length < 6)
                return version.PadLeft(6, '0');
            return version.Substring(0, 6);
        }

        if (string.Equals(version, "beta", StringComparison.OrdinalIgnoreCase))
            return "Beta";

        return version.ToUpperInvariant();
    }

    private IEnumerable<IMetadataSource> LastAddedFirst()
    {
        var snapshot = _sources;
        for (var i = snapshot.Count - 1; i >= 0; i--)
            yield return snapshot[i];
    }

    private void OverlayWithSources(SegmentDefinition derived)
    {
        var standard = derived.Standard;
        var version = derived.Version;
        if (standard == null || version == null)
            return;

        var normalized = NormalizeVersion(standard, version);
        foreach (var source in _sources)
        {
            var chosen = PickVersion(source, standard, normalized);
            if (chosen == null)
                continue;

            var packDef = source.GetSegment(standard, chosen, derived.Id);
            if (packDef == null)
                continue;

            if (!string.IsNullOrEmpty(packDef.Name))
                derived.Name = packDef.Name;

            OverlayElements(derived.Elements, packDef.Elements, source, standard, chosen);
        }
    }

    private static void OverlayElements(List<ElementDefinition> derivedElements, List<ElementDefinition> packElements, IMetadataSource source, string standard, string version)
    {
        if (packElements == null || packElements.Count == 0)
            return;

        foreach (var de in derivedElements)
        {
            ElementDefinition pe = null;
            foreach (var candidate in packElements)
            {
                if (candidate.Position == de.Position)
                {
                    pe = candidate;
                    break;
                }
            }
            if (pe == null)
                continue;

            var changed = false;

            if (!string.IsNullOrEmpty(pe.DataElementNumber)) { de.DataElementNumber = pe.DataElementNumber; changed = true; }
            if (!string.IsNullOrEmpty(pe.CompositeId)) { de.CompositeId = pe.CompositeId; changed = true; }
            if (pe.Requirement != Requirement.Unknown) { de.Requirement = pe.Requirement; changed = true; }
            if (!string.IsNullOrEmpty(pe.Name)) { de.Name = pe.Name; changed = true; }
            if (pe.DataType != ElementDataType.Unknown) { de.DataType = pe.DataType; changed = true; }
            if (pe.Decimals.HasValue) { de.Decimals = pe.Decimals; changed = true; }
            if (pe.MinLength.HasValue) { de.MinLength = pe.MinLength; changed = true; }
            if (pe.MaxLength.HasValue) { de.MaxLength = pe.MaxLength; changed = true; }

            if (!string.IsNullOrEmpty(de.DataElementNumber))
            {
                if (de.DataType == ElementDataType.Identifier || source.GetCodes(standard, version, de.DataElementNumber) != null)
                {
                    de.CodeListId = de.DataElementNumber;
                    changed = true;
                }
            }

            if (changed)
                de.Origin = source.Name;

            if (de.DataType == ElementDataType.Composite && pe.Components != null && pe.Components.Count > 0)
                OverlayElements(de.Components, pe.Components, source, standard, version);
        }
    }

    /// <summary>Picks the version from <paramref name="source"/> to use for a request: exact match, else
    /// the highest version lower than the requested one, else null (the source has nothing usable).</summary>
    private static string PickVersion(IMetadataSource source, string standard, string requestedVersion)
    {
        if (standard == null || requestedVersion == null)
            return null;

        string best = null;
        foreach (var kv in source.Versions)
        {
            if (!string.Equals(kv.Key, standard, StringComparison.Ordinal))
                continue;
            if (string.Equals(kv.Value, requestedVersion, StringComparison.Ordinal))
                return kv.Value;

            if (CompareVersions(standard, kv.Value, requestedVersion) < 0)
            {
                if (best == null || CompareVersions(standard, kv.Value, best) > 0)
                    best = kv.Value;
            }
        }
        return best;
    }

    private static int CompareVersions(string standard, string a, string b)
    {
        if (standard == "X12")
        {
            long na, nb;
            long.TryParse(a, out na);
            long.TryParse(b, out nb);
            return na.CompareTo(nb);
        }

        int yearA, yearB;
        string letterA, letterB;
        if (TryParseEdifactVersion(a, out yearA, out letterA) && TryParseEdifactVersion(b, out yearB, out letterB))
        {
            var cmp = yearA.CompareTo(yearB);
            return cmp != 0 ? cmp : string.CompareOrdinal(letterA, letterB);
        }

        return string.CompareOrdinal(a, b);
    }

    /// <summary>Parses "D96A" into a sortable (year, letter) pair where D93A..D99B sort before D00A..D21B.</summary>
    private static bool TryParseEdifactVersion(string v, out int sortableYear, out string letter)
    {
        sortableYear = 0;
        letter = null;

        if (string.IsNullOrEmpty(v) || v[0] != 'D' || v.Length < 4)
            return false;

        int yy;
        if (!int.TryParse(v.Substring(1, 2), out yy))
            return false;

        letter = v.Substring(3);
        sortableYear = yy >= 90 ? yy : 100 + yy;
        return true;
    }
}
