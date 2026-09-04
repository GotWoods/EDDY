using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Eddy.x12;

/// <summary>Code, version and CLR type of one registered transaction set model.</summary>
public class TransactionSetInfo
{
    public TransactionSetInfo(string code, string version, Type type)
    {
        Code = code;
        Version = version;
        Type = type;
    }

    public string Code { get; }
    public string Version { get; }
    public Type Type { get; }
}

/// <summary>
/// Looks up the generated transaction set model (e.g. Edi997_FunctionalAcknowledgment) for a transaction
/// set code and version. Domain model assemblies (Eddy.x12.DomainModels.*) follow the convention of a
/// class named Edi{code}_* living in a namespace whose last segment is v{version} (e.g.
/// Eddy.x12.DomainModels.CommunicationsAndControls.v4010). On first use every already-loaded assembly
/// whose name starts with "Eddy.x12.DomainModels" is registered automatically; call Register explicitly
/// for anything loaded later, or that doesn't follow that assembly naming convention.
/// </summary>
public static class TransactionSetRegistry
{
    private static readonly object Gate = new object();
    private static readonly Dictionary<string, Dictionary<string, Type>> ByCode =
        new Dictionary<string, Dictionary<string, Type>>(StringComparer.OrdinalIgnoreCase);
    private static readonly HashSet<Assembly> RegisteredAssemblies = new HashSet<Assembly>();
    private static bool _autoRegistered;

    private static readonly Regex ClassNamePattern = new Regex(@"^Edi(?<code>[A-Za-z0-9]+)_", RegexOptions.Compiled);

    /// <summary>Scans an assembly for Edi{code}_* classes under a v{version} namespace and registers them.</summary>
    public static void Register(Assembly assembly)
    {
        if (assembly == null)
            return;

        lock (Gate)
        {
            RegisterInternal(assembly);
        }
    }

    /// <summary>
    /// Resolves the model type for a transaction set code and version. Version may be given as "004010",
    /// "4010" or the raw ISA-style "00401" -- all normalise to the four-digit form the v#### namespaces
    /// use. Returns an exact version match when registered, otherwise the highest registered version below
    /// the requested one, otherwise null.
    /// </summary>
    public static Type Resolve(string transactionSetCode, string version)
    {
        if (string.IsNullOrEmpty(transactionSetCode))
            return null;

        EnsureAutoRegistered();

        lock (Gate)
        {
            if (!ByCode.TryGetValue(transactionSetCode, out var versions) || versions.Count == 0)
                return null;

            var normalized = NormalizeVersion(version);

            if (normalized != null && versions.TryGetValue(normalized, out var exact))
                return exact;

            Type best = null;
            string bestVersion = null;
            foreach (var kvp in versions)
            {
                if (normalized != null && string.CompareOrdinal(kvp.Key, normalized) >= 0)
                    continue;
                if (bestVersion == null || string.CompareOrdinal(kvp.Key, bestVersion) > 0)
                {
                    bestVersion = kvp.Key;
                    best = kvp.Value;
                }
            }

            return best;
        }
    }

    /// <summary>Every transaction set model currently registered.</summary>
    public static IReadOnlyList<TransactionSetInfo> All
    {
        get
        {
            EnsureAutoRegistered();
            lock (Gate)
            {
                var result = new List<TransactionSetInfo>();
                foreach (var codeEntry in ByCode)
                {
                    foreach (var versionEntry in codeEntry.Value)
                        result.Add(new TransactionSetInfo(codeEntry.Key, versionEntry.Key, versionEntry.Value));
                }
                return result;
            }
        }
    }

    /// <summary>Normalises a version string ("004010", "4010", "00401") to the four-digit v#### form.</summary>
    public static string NormalizeVersion(string version)
    {
        if (string.IsNullOrEmpty(version))
            return null;

        var digits = new string(version.Where(char.IsDigit).ToArray());
        if (digits.Length == 0)
            return null;

        var trimmed = digits.TrimStart('0');
        if (trimmed.Length == 0)
            trimmed = "0";

        if (trimmed.Length < 4)
            return trimmed.PadRight(4, '0');
        if (trimmed.Length > 4)
            return trimmed.Substring(0, 4);
        return trimmed;
    }

    private static void EnsureAutoRegistered()
    {
        if (_autoRegistered)
            return;

        lock (Gate)
        {
            if (_autoRegistered)
                return;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var name = assembly.GetName().Name;
                if (name != null && name.StartsWith("Eddy.x12.DomainModels", StringComparison.Ordinal))
                    RegisterInternal(assembly);
            }

            _autoRegistered = true;
        }
    }

    private static void RegisterInternal(Assembly assembly)
    {
        if (!RegisteredAssemblies.Add(assembly))
            return;

        Type[] types;
        try
        {
            types = assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            types = ex.Types.Where(t => t != null).ToArray();
        }

        foreach (var type in types)
        {
            if (type == null || !type.IsClass || type.IsAbstract || type.Namespace == null)
                continue;

            var match = ClassNamePattern.Match(type.Name);
            if (!match.Success)
                continue;

            var version = ExtractVersion(type.Namespace);
            if (version == null)
                continue;

            var code = match.Groups["code"].Value;
            if (!ByCode.TryGetValue(code, out var versions))
            {
                versions = new Dictionary<string, Type>();
                ByCode[code] = versions;
            }

            if (!versions.ContainsKey(version))
                versions[version] = type;
        }
    }

    private static string ExtractVersion(string ns)
    {
        var lastDot = ns.LastIndexOf('.');
        var lastSegment = lastDot >= 0 ? ns.Substring(lastDot + 1) : ns;
        if (lastSegment.Length < 2 || (lastSegment[0] != 'v' && lastSegment[0] != 'V'))
            return null;

        var rest = lastSegment.Substring(1);
        return rest.Length > 0 && rest.All(char.IsDigit) ? NormalizeVersion(rest) : null;
    }
}
