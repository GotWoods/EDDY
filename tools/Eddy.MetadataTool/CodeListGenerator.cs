using System.Text;

namespace Eddy.MetadataTool;

/// <summary>Generates <c>Eddy.Core.Codes.CodeList</c> subclasses (see docs/metadata-packs.md) from one or
/// more metadata packs' code lists, one <c>.cs</c> file per data element that has codes in any of the
/// given packs. Backs the `gen-codes` command.</summary>
public static class CodeListGenerator
{
    public sealed class Options
    {
        public List<string> PackPaths { get; set; } = new();
        public string Namespace { get; set; } = "";
        public string OutDir { get; set; } = "";
        public bool Enums { get; set; }
    }

    /// <summary>Result for one generated data element / class.</summary>
    public sealed class GeneratedFile
    {
        public string DataElementNumber { get; init; } = "";
        public string ClassName { get; init; } = "";
        public string Path { get; init; } = "";
    }

    public static List<GeneratedFile> Generate(Options options)
    {
        if (options.PackPaths.Count == 0)
            throw new ArgumentException("gen-codes requires at least one --pack");
        if (string.IsNullOrWhiteSpace(options.Namespace))
            throw new ArgumentException("gen-codes requires --namespace");
        if (string.IsNullOrWhiteSpace(options.OutDir))
            throw new ArgumentException("gen-codes requires --out");

        var packs = options.PackPaths.Select(p => (path: p, pack: PackJson.Load(p))).ToList();

        var elementIds = new SortedSet<string>(StringComparer.Ordinal);
        foreach (var (_, pack) in packs)
            foreach (var key in pack.Codes.Keys)
                elementIds.Add(key);

        Directory.CreateDirectory(options.OutDir);

        var results = new List<GeneratedFile>();
        var usedClassNames = new HashSet<string>(StringComparer.Ordinal);

        foreach (var elementId in elementIds)
        {
            var owningPacks = packs.Where(p => p.pack.Codes.ContainsKey(elementId)).ToList();
            var standard = owningPacks[0].pack.Standard;

            string? name = null;
            var mergedCodes = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var (_, pack) in packs)
            {
                if (string.IsNullOrEmpty(name) && pack.DataElements.TryGetValue(elementId, out var de) && !string.IsNullOrEmpty(de.Name))
                    name = de.Name;

                if (!pack.Codes.TryGetValue(elementId, out var codes))
                    continue;

                foreach (var (code, description) in codes)
                {
                    // A later pack can fill in a description an earlier one left blank, but never
                    // overwrites one that's already there.
                    if (!mergedCodes.TryGetValue(code, out var existing) || string.IsNullOrEmpty(existing))
                        mergedCodes[code] = description;
                }
            }

            var displayName = string.IsNullOrEmpty(name) ? elementId : name!;
            var baseName = PascalCaseFromWords(displayName) ?? "DataElement" + SanitizeCodeIdentifier(elementId);
            var enumName = baseName;
            var className = (baseName.EndsWith("Code", StringComparison.Ordinal)
                ? baseName.Substring(0, baseName.Length - "Code".Length)
                : baseName) + "Codes";

            // Guard against two data elements producing the same class name (e.g. two lists both
            // named "Code"): fall back to appending the data element number.
            if (!usedClassNames.Add(className))
            {
                className = className + "_" + SanitizeCodeIdentifier(elementId);
                usedClassNames.Add(className);
            }

            var memberNames = AssignMemberNames(mergedCodes);
            var hasAnyDescription = mergedCodes.Values.Any(v => !string.IsNullOrEmpty(v));
            var generateEnum = options.Enums && hasAnyDescription;

            var source = Render(options.Namespace, className, enumName, standard, elementId, displayName, mergedCodes, memberNames, generateEnum, owningPacks);
            var path = System.IO.Path.Combine(options.OutDir, className + ".cs");
            File.WriteAllText(path, source);

            results.Add(new GeneratedFile { DataElementNumber = elementId, ClassName = className, Path = path });
        }

        return results;
    }

    /// <summary>Assigns one C# identifier per code, in ordinal code order: from the description
    /// (PascalCase) when non-empty, else from the code itself. Collisions are resolved by appending the
    /// code to whichever entry loses the race.</summary>
    private static Dictionary<string, string> AssignMemberNames(Dictionary<string, string> codes)
    {
        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        var used = new HashSet<string>(StringComparer.Ordinal);

        foreach (var code in codes.Keys.OrderBy(c => c, StringComparer.Ordinal))
        {
            var description = codes[code];
            var candidate = string.IsNullOrEmpty(description)
                ? SanitizeCodeIdentifier(code)
                : PascalCaseFromWords(description) ?? SanitizeCodeIdentifier(code);

            if (!used.Add(candidate))
            {
                var suffixed = candidate + "_" + SanitizeCodeIdentifier(code);
                var attempt = suffixed;
                var n = 2;
                while (!used.Add(attempt))
                    attempt = suffixed + n++;
                candidate = attempt;
            }

            result[code] = candidate;
        }

        return result;
    }

    private static string Render(string ns, string className, string enumName, string standard, string dataElementNumber,
        string name, Dictionary<string, string> codes, Dictionary<string, string> memberNames, bool generateEnum,
        List<(string path, MetadataPackModel pack)> sourcePacks)
    {
        var sb = new StringBuilder();
        sb.AppendLine("// <auto-generated>");
        sb.AppendLine("// Generated by Eddy.MetadataTool gen-codes. Do not edit by hand - regenerate from the source pack(s) instead.");
        foreach (var (path, pack) in sourcePacks)
        {
            sb.AppendLine($"// Source: {System.IO.Path.GetFileName(path)}");
            if (!string.IsNullOrEmpty(pack.Provenance))
                sb.AppendLine($"//   Provenance: {pack.Provenance}");
            if (!string.IsNullOrEmpty(pack.License))
                sb.AppendLine($"//   License: {pack.License}");
        }
        sb.AppendLine("// </auto-generated>");
        sb.AppendLine("using Eddy.Core.Codes;");
        sb.AppendLine();
        sb.AppendLine($"namespace {ns};");
        sb.AppendLine();
        sb.AppendLine($"/// <summary>{EscapeXmlDoc(name)} ({standard} data element {dataElementNumber}).</summary>");
        sb.AppendLine($"public sealed class {className} : CodeList");
        sb.AppendLine("{");
        sb.AppendLine($"    public override string Standard => \"{standard}\";");
        sb.AppendLine($"    public override string DataElementNumber => \"{dataElementNumber}\";");
        sb.AppendLine($"    public override string Name => \"{EscapeStringLiteral(name)}\";");
        sb.AppendLine();

        foreach (var code in codes.Keys.OrderBy(c => c, StringComparer.Ordinal))
        {
            var description = codes[code];
            if (!string.IsNullOrEmpty(description))
                sb.AppendLine($"    /// <summary>{EscapeXmlDoc(description)}</summary>");
            sb.AppendLine($"    public const string {memberNames[code]} = \"{EscapeStringLiteral(code)}\";");
        }

        if (generateEnum)
        {
            sb.AppendLine();
            sb.AppendLine($"    public enum {enumName}");
            sb.AppendLine("    {");
            var orderedCodes = codes.Keys.OrderBy(c => c, StringComparer.Ordinal).ToList();
            for (var i = 0; i < orderedCodes.Count; i++)
            {
                var code = orderedCodes[i];
                var comma = i == orderedCodes.Count - 1 ? "" : ",";
                sb.AppendLine($"        [CodeValue(\"{EscapeStringLiteral(code)}\")]");
                sb.AppendLine($"        {memberNames[code]}{comma}");
            }
            sb.AppendLine("    }");
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    /// <summary>Splits on anything that is not a letter or digit, capitalising the first character of
    /// each surviving word and lower-casing the rest, e.g. "Party qualifier" -&gt; "PartyQualifier". Returns
    /// null when nothing alphanumeric survives.</summary>
    internal static string? PascalCaseFromWords(string input)
    {
        var sb = new StringBuilder();
        var newWord = true;
        foreach (var ch in input)
        {
            if (char.IsLetterOrDigit(ch))
            {
                sb.Append(newWord ? char.ToUpperInvariant(ch) : char.ToLowerInvariant(ch));
                newWord = false;
            }
            else
            {
                newWord = true;
            }
        }

        if (sb.Length == 0)
            return null;

        if (char.IsDigit(sb[0]))
            sb.Insert(0, '_');

        return sb.ToString();
    }

    /// <summary>Strips characters that cannot appear in a C# identifier, preserving case, and prefixes an
    /// underscore when the result would start with a digit (or be empty).</summary>
    internal static string SanitizeCodeIdentifier(string code)
    {
        var sb = new StringBuilder();
        foreach (var ch in code)
        {
            if (char.IsLetterOrDigit(ch) || ch == '_')
                sb.Append(ch);
        }

        if (sb.Length == 0)
            return "_";

        if (char.IsDigit(sb[0]))
            sb.Insert(0, '_');

        return sb.ToString();
    }

    private static string EscapeStringLiteral(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");

    private static string EscapeXmlDoc(string value) => value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
}
