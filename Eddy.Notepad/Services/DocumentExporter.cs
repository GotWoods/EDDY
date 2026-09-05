using System.Globalization;
using System.Text;
using System.Text.Json;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>
/// File &gt; Export ▸ Text/JSON/CSV (see MainWindowViewModel's export commands). Pure text-producing
/// functions -- no file I/O here, so they are unit-testable on their own; the view model writes whatever
/// they return with <see cref="IFilePicker"/> and UTF-8 without a BOM, the same way Save does.
/// </summary>
public static class DocumentExporter
{
    // ==== Text: one segment per line ======================================================================

    /// <summary><paramref name="document"/>'s raw text, with a newline inserted after every segment
    /// terminator that is not already followed by one -- so the export is one segment per line even for a
    /// document whose terminator is not itself a newline and was not written with one after it. A no-op
    /// (returns <see cref="DocumentViewModel.RawText"/> unchanged) when the terminator already is a
    /// newline.</summary>
    public static string ExportText(DocumentViewModel document)
    {
        var text = document.RawText;
        var terminator = DetermineTerminator(document);
        if (terminator == '\n')
            return text;

        var sb = new StringBuilder(text.Length + 16);
        for (var i = 0; i < text.Length; i++)
        {
            sb.Append(text[i]);
            if (text[i] == terminator && (i + 1 >= text.Length || text[i + 1] != '\n'))
                sb.Append('\n');
        }

        return sb.ToString();
    }

    /// <summary>
    /// X12's ISA header is a fixed 106 characters, the 106th (index 105) being the segment terminator --
    /// the same field DocumentLoader.cs's own raw-line fallback reads. EDIFACT's terminator is the last
    /// character of the 9-character UNA service string advice when the file has one (e.g. "UNA:+.? '" ->
    /// "'"), else the standard default "'" apostrophe. Anything else (a document with no envelope the
    /// loader could make sense of) falls back to '\n', which makes <see cref="ExportText"/> a no-op.
    /// </summary>
    private static char DetermineTerminator(DocumentViewModel document)
    {
        var text = document.RawText;

        if (document.Format.StartsWith("X12", StringComparison.Ordinal))
            return text.Length >= 106 ? text[105] : '\n';

        if (document.Format.StartsWith("EDIFACT", StringComparison.Ordinal))
            return text.StartsWith("UNA", StringComparison.Ordinal) && text.Length >= 9 ? text[8] : '\'';

        return '\n';
    }

    // ==== JSON: interchanges > groups > transaction sets/messages > segments > elements ==================

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    /// <summary>
    /// One JSON object: "format", "diagnostics" (line/severity/message, document order) and "interchanges"
    /// -- a tree mirroring <see cref="DocumentViewModel.Nodes"/>/<see cref="DocumentNodeViewModel.Children"/>
    /// exactly (so "interchanges" holds functional groups, which hold transaction sets or messages, which
    /// hold segments), each node carrying its own "elements" (ref/name/value/de/type; composite sub-elements
    /// are not broken out separately -- a composite's value is already its joined component text, same as
    /// the element grid shows) alongside "kind"/"code"/"title"/"line" and its nested "children".
    /// </summary>
    public static string ExportJson(DocumentViewModel document)
    {
        var root = new ExportedDocument
        {
            Format = document.Format,
            Diagnostics = document.Diagnostics.Select(ToExportedDiagnostic).ToList(),
            Interchanges = document.Nodes.Select(ToExportedNode).ToList(),
        };

        return JsonSerializer.Serialize(root, JsonOptions);
    }

    private static ExportedDiagnostic ToExportedDiagnostic(DiagnosticViewModel diagnostic) => new()
    {
        Line = diagnostic.LineNumber,
        Severity = diagnostic.Severity.ToString(),
        Message = diagnostic.Message,
    };

    private static ExportedNode ToExportedNode(DocumentNodeViewModel node) => new()
    {
        Kind = node.Kind.ToString(),
        Code = node.Code,
        Title = node.Title,
        Line = node.LineNumber,
        Elements = node.Elements.Select(ToExportedElement).ToList(),
        Children = node.Children.Select(ToExportedNode).ToList(),
    };

    private static ExportedElement ToExportedElement(ElementViewModel element) => new()
    {
        Ref = element.Reference,
        Name = element.Name,
        Value = element.Value,
        De = element.DataElementNumber,
        Type = element.DataTypeLabel,
    };

    private sealed class ExportedDocument
    {
        public string Format { get; init; } = "";
        public List<ExportedDiagnostic> Diagnostics { get; init; } = new();
        public List<ExportedNode> Interchanges { get; init; } = new();
    }

    private sealed class ExportedDiagnostic
    {
        public int? Line { get; init; }
        public string Severity { get; init; } = "";
        public string Message { get; init; } = "";
    }

    private sealed class ExportedNode
    {
        public string Kind { get; init; } = "";
        public string Code { get; init; } = "";
        public string Title { get; init; } = "";
        public int? Line { get; init; }
        public List<ExportedElement> Elements { get; init; } = new();
        public List<ExportedNode> Children { get; init; } = new();
    }

    private sealed class ExportedElement
    {
        public string Ref { get; init; } = "";
        public string Name { get; init; } = "";
        public string? Value { get; init; }
        public string? De { get; init; }
        public string Type { get; init; } = "";
    }

    // ==== CSV: one row per element =========================================================================

    private static readonly string[] CsvHeader =
        { "line", "segment", "ref", "name", "value", "de", "type", "req", "meaning" };

    /// <summary>One header row plus one row per element of every node in the document (envelope headers'
    /// own elements -- ISA/GS/ST, UNB/UNG/UNH -- included, composite sub-elements not broken out
    /// separately; same choice as <see cref="ExportJson"/>, for the same reason).</summary>
    public static string ExportCsv(DocumentViewModel document)
    {
        var sb = new StringBuilder();
        sb.Append(string.Join(",", CsvHeader)).Append('\n');

        foreach (var node in AllNodes(document.Nodes))
        {
            foreach (var element in node.Elements)
            {
                var fields = new[]
                {
                    node.LineNumber?.ToString(CultureInfo.InvariantCulture) ?? "",
                    node.Code,
                    element.Reference,
                    element.Name,
                    element.Value ?? "",
                    element.DataElementNumber ?? "",
                    element.DataTypeLabel,
                    element.Requirement,
                    element.Meaning,
                };
                sb.Append(string.Join(",", fields.Select(CsvField))).Append('\n');
            }
        }

        return sb.ToString();
    }

    private static IEnumerable<DocumentNodeViewModel> AllNodes(IEnumerable<DocumentNodeViewModel> nodes)
    {
        foreach (var node in nodes)
        {
            yield return node;
            foreach (var descendant in AllNodes(node.Children))
                yield return descendant;
        }
    }

    private static string CsvField(string value)
    {
        if (value.IndexOfAny(new[] { ',', '"', '\n', '\r' }) < 0)
            return value;
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}
