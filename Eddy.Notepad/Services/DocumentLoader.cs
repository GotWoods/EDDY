using System.Reflection;
using Eddy.Core.Validation;
using Eddy.Notepad.ViewModels;
using SegmentAttribute = Eddy.Core.Attributes.Segment;

namespace Eddy.Notepad.Services;

/// <summary>
/// Parses EDI text with the Eddy libraries and builds the tree, raw lines and diagnostics.
/// See README.md, "Loader contract", for the rules this must follow. Never throws.
///
/// This file holds the entry point and the pieces shared by both formats (normalisation, format
/// detection, raw line assembly from Source spans, diagnostics from ValidationResults, severity
/// mapping, summary wording). The X12-specific and EDIFACT-specific tree building live in
/// DocumentLoader.X12.cs and DocumentLoader.Edifact.cs, which read alike by design: same method
/// names and shapes, one set of model types swapped for the other.
/// </summary>
public sealed partial class DocumentLoader : IDocumentLoader
{
    public DocumentViewModel Load(string text, string displayName, string? filePath)
    {
        try
        {
            return LoadCore(text, displayName, filePath);
        }
        catch (Exception ex)
        {
            // The contract says this must never throw. Eddy.x12's and Eddy.Edifact's lenient modes never
            // throw for content problems, so this is a last resort for anything we did not anticipate.
            var fallback = new DocumentViewModel(displayName, filePath, "Unknown", text ?? "");
            fallback.RawLines = Array.Empty<RawLineViewModel>();
            fallback.Diagnostics.Add(new DiagnosticViewModel(DiagnosticSeverity.Error, null, "", $"Could not load this file: {ex.Message}"));
            fallback.Summary = "Load failed";
            return fallback;
        }
    }

    private static DocumentViewModel LoadCore(string text, string displayName, string? filePath)
    {
        var normalized = Normalize(text);
        var kind = DetectFormat(normalized);

        return kind switch
        {
            "X12" => LoadX12(normalized, displayName, filePath),
            "EDIFACT" => LoadEdifact(normalized, displayName, filePath),
            _ => LoadUnsupported(normalized, displayName, filePath, kind),
        };
    }

    private static DocumentViewModel LoadUnsupported(string normalized, string displayName, string? filePath, string kind)
    {
        var document = new DocumentViewModel(displayName, filePath, kind, normalized);
        document.RawLines = SplitRawLines(normalized, '\n');
        document.Diagnostics.Add(new DiagnosticViewModel(DiagnosticSeverity.Info, null, "", $"{kind} is not supported yet."));
        document.Summary = kind;
        return document;
    }

    // ---- normalisation and format detection (rules 1-2) ----------------------------------------------

    private static string Normalize(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        if (text[0] == '﻿')
            text = text[1..];

        text = text.Replace("\r\n", "\n").Replace('\r', '\n');
        return text.Trim();
    }

    private static string DetectFormat(string text)
    {
        if (text.StartsWith("ISA", StringComparison.Ordinal))
            return "X12";
        if (text.StartsWith("UNA", StringComparison.Ordinal) || text.StartsWith("UNB", StringComparison.Ordinal))
            return "EDIFACT";
        return "Unknown";
    }

    // ---- raw lines --------------------------------------------------------------------------------------

    private static List<RawLineViewModel> SplitRawLines(string text, char terminator)
    {
        var result = new List<RawLineViewModel>();
        var number = 1;
        foreach (var piece in text.Split(terminator))
        {
            var trimmed = piece.Trim();
            if (trimmed.Length == 0)
                continue;
            result.Add(new RawLineViewModel(number, trimmed));
            number++;
        }

        return result;
    }

    /// <summary>
    /// Raw lines come from the parser's SegmentSource spans, not from re-splitting the text: every parsed
    /// object that carries a Source contributes one line, in Source.LineNumber order, with RawText taken
    /// verbatim from Source.RawText. When the parser stopped early we don't have spans for the rest of the
    /// file, so fall back to the plain text split used for unsupported documents.
    /// </summary>
    private static List<RawLineViewModel> BuildRawLines(
        string normalized,
        List<(int LineNumber, string RawText)> sources,
        bool stoppedEarly,
        IReadOnlyDictionary<int, DocumentNodeViewModel> lineToNode)
    {
        List<RawLineViewModel> lines;
        if (!stoppedEarly && sources.Count > 0)
        {
            lines = sources
                .OrderBy(s => s.LineNumber)
                .Select(s => new RawLineViewModel(s.LineNumber, s.RawText))
                .ToList();
        }
        else
        {
            var terminator = normalized.Length >= 106 ? normalized[105] : '\n';
            lines = SplitRawLines(normalized, terminator);
        }

        foreach (var line in lines)
        {
            if (lineToNode.TryGetValue(line.LineNumber, out var node))
                line.Node = node;
        }

        return lines;
    }

    // ---- shared tree-building helpers --------------------------------------------------------------------

    private static string GetSegmentCode(object model) =>
        model.GetType().GetCustomAttribute<SegmentAttribute>()?.Name ?? model.GetType().Name;

    private static string NamePartOf(string typeName)
    {
        var underscoreIndex = typeName.IndexOf('_');
        return underscoreIndex >= 0 && underscoreIndex < typeName.Length - 1
            ? typeName[(underscoreIndex + 1)..]
            : "";
    }

    // ---- summary wording ("X12 004010 · 2 interchanges · 3 groups · 5 transaction sets · 1 error", or the
    // EDIFACT equivalent with "message" instead of "transaction set") ------------------------------------

    private static string Pluralize(int count, string word) => $"{count} {word}{(count == 1 ? "" : "s")}";

    private static string BuildEnvelopeSummary(string format, int interchangeCount, int groupCount, int leafCount, string leafWord, int errorCount) =>
        $"{format} · {Pluralize(interchangeCount, "interchange")} · {Pluralize(groupCount, "group")} · " +
        $"{Pluralize(leafCount, leafWord)} · {Pluralize(errorCount, "error")}";

    // ---- diagnostics --------------------------------------------------------------------------------------

    private static Dictionary<int, List<Error>> GroupErrorsByLine(List<ValidationResult> validationErrors)
    {
        var map = new Dictionary<int, List<Error>>();
        foreach (var result in validationErrors)
        {
            if (!map.TryGetValue(result.LineNumber, out var list))
            {
                list = new List<Error>();
                map[result.LineNumber] = list;
            }

            list.AddRange(result.Errors);
        }

        return map;
    }

    private static IReadOnlyList<Error> ErrorsFor(IReadOnlyDictionary<int, List<Error>> errorsByLine, int? lineNumber) =>
        lineNumber is int line && errorsByLine.TryGetValue(line, out var errors) ? errors : Array.Empty<Error>();

    private static void BuildDiagnostics(
        DocumentViewModel document,
        List<ValidationResult> validationErrors,
        IReadOnlyList<ErrorCodes> warningCodes,
        IReadOnlyList<RawLineViewModel> rawLines)
    {
        foreach (var result in validationErrors)
        {
            var lineNumber = result.LineNumber;
            var rawLine = rawLines.FirstOrDefault(r => r.LineNumber == lineNumber);
            var segmentCode = result.SegmentCode ?? SegmentCodeAt(rawLine);

            foreach (var error in result.Errors)
            {
                var diagnostic = new DiagnosticViewModel(
                    SeverityFor(error.ErrorCode, warningCodes),
                    lineNumber == 0 ? null : lineNumber,
                    segmentCode ?? "",
                    error.ToString() ?? "")
                {
                    Node = rawLine?.Node,
                };
                document.Diagnostics.Add(diagnostic);
                rawLine?.Node?.Diagnostics.Add(diagnostic);

                if (rawLine is not null)
                    rawLine.HasError = true;
            }
        }
    }

    /// <summary>A missing trailer or a segment stranded outside its container are warnings; everything else is an error.</summary>
    private static DiagnosticSeverity SeverityFor(ErrorCodes code, IReadOnlyList<ErrorCodes> warningCodes)
    {
        for (var i = 0; i < warningCodes.Count; i++)
        {
            if (ReferenceEquals(warningCodes[i], code))
                return DiagnosticSeverity.Warning;
        }

        return DiagnosticSeverity.Error;
    }

    private static readonly IReadOnlyList<ErrorCodes> X12WarningCodes =
        new[] { ErrorCodes.MissingTrailer, ErrorCodes.SegmentOutsideTransactionSet };

    private static readonly IReadOnlyList<ErrorCodes> EdifactWarningCodes =
        new[] { ErrorCodes.EdiFactUnsupportedVersion, ErrorCodes.EdiFactMissingTrailer, ErrorCodes.EdiFactSegmentOutsideMessage };

    private static string SegmentCodeAt(RawLineViewModel? rawLine)
    {
        if (rawLine is null)
            return "";

        var text = rawLine.Text;
        var i = 0;
        while (i < text.Length && char.IsLetterOrDigit(text[i]))
            i++;
        return text[..i];
    }
}
