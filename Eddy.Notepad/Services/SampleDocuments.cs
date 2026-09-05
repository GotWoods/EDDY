using System.Reflection;

namespace Eddy.Notepad.Services;

/// <summary>Bundled sample files, embedded from the Samples folder.</summary>
public static class SampleDocuments
{
    private const string Prefix = "Eddy.Notepad.Samples.";

    public static IReadOnlyList<string> GetNames()
    {
        return typeof(SampleDocuments).Assembly.GetManifestResourceNames()
            .Where(n => n.StartsWith(Prefix, StringComparison.Ordinal) && n.EndsWith(".edi", StringComparison.Ordinal))
            .Select(n => n.Substring(Prefix.Length, n.Length - Prefix.Length - ".edi".Length))
            .OrderBy(n => n, StringComparer.Ordinal)
            .ToList();
    }

    public static string GetText(string name)
    {
        var resource = Prefix + name + ".edi";
        using var stream = typeof(SampleDocuments).Assembly.GetManifestResourceStream(resource)
            ?? throw new FileNotFoundException($"Sample '{name}' is not embedded in the application.", resource);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
