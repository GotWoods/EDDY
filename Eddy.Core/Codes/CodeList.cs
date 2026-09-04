using System;
using Eddy.Core.Metadata;

namespace Eddy.Core.Codes;

/// <summary>
/// Base class for a generated (or hand-written) standard code list: the set of values a given data
/// element is allowed to hold, e.g. X12 data element 98 (Entity Identifier Code) or EDIFACT 3035
/// (Party Qualifier). <see cref="Code{TList}"/> is the value type that carries one such code around;
/// this class only answers "is this code known" and "what does it mean" questions, through
/// <see cref="Catalog"/>.
/// </summary>
public abstract class CodeList
{
    /// <summary>
    /// The catalog every <see cref="CodeList"/> subclass answers Contains/Describe questions through.
    /// Defaults to <see cref="MetadataCatalog.Default"/>. Tests that need a private, disposable set of
    /// packs may substitute their own catalog here and must restore the previous value afterward -
    /// this is process-wide, shared state.
    /// </summary>
    public static MetadataCatalog Catalog { get; set; } = MetadataCatalog.Default;

    /// <summary>"X12" or "EDIFACT".</summary>
    public abstract string Standard { get; }

    /// <summary>Standard data element number this list answers for, e.g. "98" (X12) or "3035" (EDIFACT).</summary>
    public abstract string DataElementNumber { get; }

    /// <summary>Human readable name of the code list, e.g. "Entity Identifier Code".</summary>
    public abstract string Name { get; }

    /// <summary>
    /// Is <paramref name="code"/> a known value of this list? When <paramref name="version"/> is null,
    /// a code counts as known if any version of <see cref="Standard"/> loaded into <see cref="Catalog"/>
    /// knows it; otherwise only that exact (normalised) version is consulted.
    /// </summary>
    public bool Contains(string code, string version = null)
    {
        if (string.IsNullOrEmpty(code))
            return false;

        var codes = LookupCodes(version);
        return codes != null && codes.ContainsKey(code);
    }

    /// <summary>Description of <paramref name="code"/> from the loaded catalog, or null when unknown
    /// (either because no list is loaded, or the code is not in it). See <see cref="Contains"/> for how
    /// <paramref name="version"/> is resolved.</summary>
    public string Describe(string code, string version = null)
    {
        if (string.IsNullOrEmpty(code))
            return null;

        var codes = LookupCodes(version);
        string description;
        return codes != null && codes.TryGetValue(code, out description) ? description : null;
    }

    private System.Collections.Generic.IReadOnlyDictionary<string, string> LookupCodes(string version)
    {
        var catalog = Catalog ?? MetadataCatalog.Default;
        return version != null
            ? catalog.GetCodes(Standard, version, DataElementNumber)
            : catalog.GetCodesAnyVersion(Standard, DataElementNumber);
    }
}

/// <summary>
/// Applied to a field of a generated code enum to record the standard code value it represents, e.g.
/// <c>[CodeValue("BY")] Buyer</c>. When absent, <see cref="Code{TList}"/> falls back to the field's own
/// name as the code.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class CodeValueAttribute : Attribute
{
    public string Code { get; }

    public CodeValueAttribute(string code)
    {
        Code = code;
    }
}
