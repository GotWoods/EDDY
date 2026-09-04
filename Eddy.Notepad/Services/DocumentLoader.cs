using System.Reflection;
using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Notepad.ViewModels;
using Eddy.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using SegmentAttribute = Eddy.Core.Attributes.Segment;

namespace Eddy.Notepad.Services;

/// <summary>
/// Parses EDI text with the Eddy libraries and builds the tree, raw lines and diagnostics.
/// See README.md, "Loader contract", for the rules this must follow. Never throws.
/// </summary>
public sealed class DocumentLoader : IDocumentLoader
{
    public DocumentViewModel Load(string text, string displayName, string? filePath)
    {
        try
        {
            return LoadCore(text, displayName, filePath);
        }
        catch (Exception ex)
        {
            // The contract says this must never throw. If something we did not anticipate goes wrong,
            // fall back to a document that at least explains why.
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

        if (kind != "X12")
        {
            var document = new DocumentViewModel(displayName, filePath, kind, normalized);
            document.RawLines = SplitRawLines(normalized, '\n');
            document.Diagnostics.Add(new DiagnosticViewModel(DiagnosticSeverity.Info, null, "", $"{kind} is not supported yet."));
            document.Summary = kind;
            return document;
        }

        if (normalized.Length < 106)
        {
            var document = new DocumentViewModel(displayName, filePath, "X12", normalized);
            document.RawLines = SplitRawLines(normalized, '\n');
            document.Diagnostics.Add(new DiagnosticViewModel(
                DiagnosticSeverity.Error, 1, "ISA",
                $"Expected the ISA segment to be at least 106 characters long but it was {normalized.Length} characters."));
            document.Summary = "X12";
            return document;
        }

        var terminator = normalized[105];
        var rawLines = SplitRawLines(normalized, terminator);

        // x12Document.Parse locates GS by checking that the second split line starts with "GS", without
        // trimming it first. That check breaks on files (like our own Sample-214) where the segment
        // terminator is followed by a newline for readability, because the split leaves that newline
        // attached to the front of the next piece. We already have the exact trimmed, blank-free line
        // list the README's raw-line rule calls for (rule 3), so we feed the parser a reconstruction of
        // the document built from that list instead of the original text. This does not change what is
        // displayed to the user (RawLines still comes from the original text) and is a no-op whenever the
        // file has no such stray whitespace.
        var textForParse = rawLines.Count > 0
            ? string.Join(terminator.ToString(), rawLines.Select(r => r.Text)) + terminator
            : normalized;

        x12Document parsed;
        try
        {
            parsed = x12Document.Parse(textForParse);
        }
        catch (Exception ex)
        {
            var (line, code) = LocateFailure(normalized, rawLines);
            var message = string.IsNullOrEmpty(code)
                ? ex.Message
                : $"Could not parse segment '{code}': {ex.Message}";

            var document = new DocumentViewModel(displayName, filePath, "X12", normalized);
            document.RawLines = rawLines;
            document.Diagnostics.Add(new DiagnosticViewModel(DiagnosticSeverity.Error, line, code, message));
            document.Summary = "X12";
            return document;
        }

        var version = parsed.GsHeader?.VersionReleaseIndustryIdentifierCode;
        var format = string.IsNullOrWhiteSpace(version) ? "X12" : $"X12 {version}";

        var result = new DocumentViewModel(displayName, filePath, format, normalized);
        result.RawLines = rawLines;

        var errorsByLine = GroupErrorsByLine(parsed);
        BuildTree(result, parsed, rawLines, errorsByLine);
        BuildDiagnostics(result, parsed, rawLines, parsed.InterchangeControlHeader.DataElementSeparator);
        result.Summary = BuildSummary(parsed);

        return result;
    }

    // ---- normalisation and format detection (rules 1-2) ----------------------------------------------

    private static string Normalize(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        if (text[0] == '\uFEFF')
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

    // ---- raw lines (rule 3) ---------------------------------------------------------------------------

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

    // ---- locating a line number for a parse failure (rule 4) ------------------------------------------

    private static (int? Line, string Code) LocateFailure(string normalized, IReadOnlyList<RawLineViewModel> rawLines)
    {
        GenericInterchangeControlHeader header;
        try
        {
            header = GenericInterchangeControlHeader.FromString(normalized[..106]);
        }
        catch
        {
            return (1, "ISA");
        }

        var version = (header.InterchangeControlVersionNumberCode ?? "") + "0";
        var options = new MapOptions
        {
            Separator = header.DataElementSeparator.ToString(),
            ComponentElementSeparator = header.ComponentDataElementSeparator,
            LineEnding = header.ElementSeparator.ToString(),
            StandardsVersion = version,
        };

        var inSection = false;
        foreach (var line in rawLines)
        {
            if (line.LineNumber == 1)
                continue;

            if (line.LineNumber == 2)
            {
                try
                {
                    Map.MapObject<GenericFunctionalGroupHeader>(line.Text, options);
                }
                catch
                {
                    return (2, "GS");
                }

                continue;
            }

            var text = line.Text;
            if (text.StartsWith("ST", StringComparison.Ordinal))
            {
                inSection = true;
                continue;
            }

            if (text.StartsWith("SE", StringComparison.Ordinal))
            {
                inSection = false;
                continue;
            }

            if (text.StartsWith("GE", StringComparison.Ordinal))
                continue;

            if (!inSection)
                continue;

            var separatorIndex = text.IndexOf(options.Separator, StringComparison.Ordinal);
            var code = separatorIndex >= 0 ? text[..separatorIndex] : text;

            try
            {
                EdiSectionParserFactory.Parse(version, text, options);
            }
            catch
            {
                return (line.LineNumber, code);
            }
        }

        return (null, "");
    }

    // ---- tree building (rules 5-7) ---------------------------------------------------------------------

    private static void BuildTree(
        DocumentViewModel document,
        x12Document parsed,
        IReadOnlyList<RawLineViewModel> rawLines,
        IReadOnlyDictionary<int, List<Error>> errorsByLine)
    {
        var idx = 0;
        if (idx >= rawLines.Count)
            return;

        var isaLine = rawLines[idx++];
        var interchangeNode = new DocumentNodeViewModel(
            NodeKind.Interchange, "ISA", "ISA", InterchangeSubtitle(parsed.InterchangeControlHeader), isaLine.LineNumber, parsed.InterchangeControlHeader)
        {
            Elements = SegmentElementReader.Read(parsed.InterchangeControlHeader, "ISA", MessagesFor(errorsByLine, isaLine.LineNumber)),
        };
        isaLine.Node = interchangeNode;
        document.Nodes.Add(interchangeNode);

        if (idx >= rawLines.Count || parsed.GsHeader is null)
            return;

        var gsLine = rawLines[idx++];
        var groupNode = new DocumentNodeViewModel(
            NodeKind.FunctionalGroup, "GS", "GS", GroupSubtitle(parsed.GsHeader), gsLine.LineNumber, parsed.GsHeader)
        {
            Elements = SegmentElementReader.Read(parsed.GsHeader, "GS", MessagesFor(errorsByLine, gsLine.LineNumber)),
        };
        gsLine.Node = groupNode;
        interchangeNode.Children.Add(groupNode);

        foreach (var section in parsed.Sections)
        {
            // x12Document.Parse never clears its "current section" reference after an SE line, so the
            // IEA trailer at the very end of the file (which has no dedicated handling branch of its own)
            // falls through into whatever section was open and is appended to it as if it were an ordinary
            // segment. We filter that artifact out here rather than showing a bogus "IEA" segment node
            // inside the transaction set.
            var segments = section.Segments.Where(s => !IsInterchangeTrailerArtifact(s)).ToList();

            if (idx >= rawLines.Count)
                break;

            var stLine = rawLines[idx++];
            var transactionSetCode = section.SectionType ?? "";
            var transactionSetNode = new DocumentNodeViewModel(
                NodeKind.TransactionSet,
                transactionSetCode,
                $"ST {transactionSetCode}",
                $"{section.TransactionSetControlNumber} · {segments.Count} segments",
                stLine.LineNumber,
                section);
            stLine.Node = transactionSetNode;
            groupNode.Children.Add(transactionSetNode);

            foreach (var segment in segments)
            {
                if (idx >= rawLines.Count)
                    break;

                var segmentLine = rawLines[idx++];
                var segmentNode = BuildSegmentNode(segment, segmentLine.LineNumber, MessagesFor(errorsByLine, segmentLine.LineNumber));
                segmentLine.Node = segmentNode;
                transactionSetNode.Children.Add(segmentNode);
            }

            idx++; // SE: not represented as a tree node.
        }

        idx++; // GE
        idx++; // IEA
    }

    private static bool IsInterchangeTrailerArtifact(EdiX12Segment segment) => GetSegmentCode(segment) == "IEA";

    private static string GetSegmentCode(object model) =>
        model.GetType().GetCustomAttribute<SegmentAttribute>()?.Name ?? model.GetType().Name;

    private static DocumentNodeViewModel BuildSegmentNode(EdiX12Segment segment, int lineNumber, IReadOnlyList<string> errorMessages)
    {
        var type = segment.GetType();
        var code = GetSegmentCode(segment);
        var namePart = NamePartOf(type.Name);
        var title = namePart.Length == 0 ? code : $"{code} {DisplayNames.SplitPascalCase(namePart)}";

        var elements = SegmentElementReader.Read(segment, code, errorMessages);
        var subtitle = string.Join(" ", elements.Where(e => e.HasValue).Select(e => e.Value).Take(3));

        return new DocumentNodeViewModel(NodeKind.Segment, code, title, subtitle, lineNumber, segment)
        {
            Elements = elements,
        };
    }

    private static string NamePartOf(string typeName)
    {
        var underscoreIndex = typeName.IndexOf('_');
        return underscoreIndex >= 0 && underscoreIndex < typeName.Length - 1
            ? typeName[(underscoreIndex + 1)..]
            : "";
    }

    private static string InterchangeSubtitle(GenericInterchangeControlHeader header)
    {
        var control = header.InterchangeControlNumber?.ToString("D9") ?? "";
        var sender = (header.InterchangeSenderID ?? "").Trim();
        var receiver = (header.InterchangeReceiverID ?? "").Trim();

        string date;
        try
        {
            date = header.GetDateTime().ToString("yyyy-MM-dd");
        }
        catch
        {
            date = header.InterchangeDate ?? "";
        }

        return $"{control} · {sender} -> {receiver} · {date}";
    }

    private static string GroupSubtitle(GenericFunctionalGroupHeader header)
    {
        var sender = (header.ApplicationSendersCode ?? "").Trim();
        var receiver = (header.ApplicationReceiversCode ?? "").Trim();
        return $"{header.FunctionalIdentifierCode} · {sender} -> {receiver} · {header.VersionReleaseIndustryIdentifierCode}";
    }

    private static string BuildSummary(x12Document parsed)
    {
        var isa = parsed.InterchangeControlHeader;
        var gs = parsed.GsHeader;
        var control = isa.InterchangeControlNumber?.ToString("D9") ?? "";
        var sectionCount = parsed.Sections.Count;
        var plural = sectionCount == 1 ? "" : "s";
        var sender = (gs?.ApplicationSendersCode ?? "").Trim();
        var receiver = (gs?.ApplicationReceiversCode ?? "").Trim();
        return $"ISA {control} · GS {gs?.FunctionalIdentifierCode} {sender} → {receiver} · {sectionCount} transaction set{plural}";
    }

    // ---- diagnostics (rule 8) --------------------------------------------------------------------------

    private static Dictionary<int, List<Error>> GroupErrorsByLine(x12Document parsed)
    {
        var map = new Dictionary<int, List<Error>>();
        foreach (var result in parsed.ValidationErrors)
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

    private static IReadOnlyList<string> MessagesFor(IReadOnlyDictionary<int, List<Error>> errorsByLine, int? lineNumber)
    {
        if (lineNumber is int line && errorsByLine.TryGetValue(line, out var errors))
            return errors.Select(e => e.ToString() ?? "").ToList();
        return Array.Empty<string>();
    }

    private static void BuildDiagnostics(DocumentViewModel document, x12Document parsed, IReadOnlyList<RawLineViewModel> rawLines, char separator)
    {
        foreach (var result in parsed.ValidationErrors)
        {
            var lineNumber = result.LineNumber;
            var rawLine = rawLines.FirstOrDefault(r => r.LineNumber == lineNumber);
            var segmentCode = SegmentCodeAt(rawLine, separator);

            foreach (var error in result.Errors)
            {
                var diagnostic = new DiagnosticViewModel(
                    DiagnosticSeverity.Error,
                    lineNumber == 0 ? null : lineNumber,
                    segmentCode,
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

    private static string SegmentCodeAt(RawLineViewModel? rawLine, char separator)
    {
        if (rawLine is null)
            return "";

        var text = rawLine.Text;
        var separatorIndex = text.IndexOf(separator);
        return separatorIndex >= 0 ? text[..separatorIndex] : text;
    }
}
