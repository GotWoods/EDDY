using System.Reflection;
using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Notepad.ViewModels;
using Eddy.x12;
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
            // The contract says this must never throw. Eddy.x12's lenient mode never throws for content
            // problems, so this is a last resort for anything we did not anticipate.
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

        var parsed = x12Document.Parse(normalized, new x12ParseOptions { Lenient = true });

        var format = FormatOf(parsed);
        var result = new DocumentViewModel(displayName, filePath, format, normalized);

        var errorsByLine = GroupErrorsByLine(parsed);
        var (lineToNode, sources) = BuildTree(result, parsed, errorsByLine);

        // A bad ISA is the only thing that stops the parser outright (InvalidInterchangeHeader), possibly
        // leaving Interchanges empty (the file's very first ISA was bad) or partial (a later one was, in a
        // multi-interchange file). Either way the parser produced no Source spans for whatever comes after
        // the failure point, so fall back to a plain text split to keep the raw view showing the whole file.
        var stoppedEarly = parsed.ValidationErrors.Any(r => r.Errors.Any(e => ReferenceEquals(e.ErrorCode, ErrorCodes.InvalidInterchangeHeader)));
        result.RawLines = BuildRawLines(normalized, sources, stoppedEarly, lineToNode);

        BuildDiagnostics(result, parsed, result.RawLines);
        result.Summary = BuildSummary(parsed, format);

        return result;
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
    /// object that carries a Source (ISA header, GS headers, ST headers, segments, SE/GE/IEA trailers,
    /// orphan segments, Unknown_Segment instances) contributes one line, in Source.LineNumber order, with
    /// RawText taken verbatim from Source.RawText. When the parser stopped early we don't have spans for
    /// the rest of the file, so fall back to the plain text split used for non-X12 documents.
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

    // ---- tree building ----------------------------------------------------------------------------------

    /// <summary>
    /// Builds one Interchange node per x12Interchange, one FunctionalGroup node per x12FunctionalGroup, one
    /// TransactionSet node per Section and Segment nodes for its segments. Orphan segments become Segment
    /// nodes under their container, placed by line number among their siblings. SE/GE/IEA trailers do not
    /// get their own nodes: their line number is mapped to the container node they close, so a diagnostic
    /// on a trailer line lands on that node. Returns the line-number-to-node map (used both for that
    /// purpose and to attach nodes to raw lines) and every Source span found, for BuildRawLines.
    /// </summary>
    private static (Dictionary<int, DocumentNodeViewModel> LineToNode, List<(int LineNumber, string RawText)> Sources) BuildTree(
        DocumentViewModel document,
        x12Document parsed,
        IReadOnlyDictionary<int, List<Error>> errorsByLine)
    {
        var lineToNode = new Dictionary<int, DocumentNodeViewModel>();
        var sources = new List<(int LineNumber, string RawText)>();

        void Track(ISourceTracked? tracked)
        {
            if (tracked?.Source is { } src)
                sources.Add((src.LineNumber, src.RawText));
        }

        foreach (var interchange in parsed.Interchanges)
        {
            if (interchange.Header is null)
                continue; // Never happens: an interchange is only created once its ISA header parses.

            Track(interchange.Header);
            var isaLine = interchange.Header.Source?.LineNumber;
            var interchangeNode = new DocumentNodeViewModel(
                NodeKind.Interchange, "ISA", "ISA", InterchangeSubtitle(interchange.Header), isaLine, interchange.Header)
            {
                Elements = SegmentElementReader.Read(interchange.Header, "ISA", ErrorsFor(errorsByLine, isaLine)),
            };
            if (isaLine is int il)
                lineToNode[il] = interchangeNode;
            document.Nodes.Add(interchangeNode);

            if (interchange.Trailer is not null)
            {
                Track(interchange.Trailer);
                if (interchange.Trailer.Source?.LineNumber is int ieaLine)
                    lineToNode[ieaLine] = interchangeNode;
            }

            var interchangeChildren = new List<(int LineNumber, DocumentNodeViewModel Node)>();

            foreach (var orphan in interchange.OrphanSegments)
            {
                Track(orphan);
                var line = orphan.Source?.LineNumber;
                var node = BuildSegmentNode(orphan, line, ErrorsFor(errorsByLine, line), "(outside any transaction set) ");
                if (line is int ol)
                    lineToNode[ol] = node;
                interchangeChildren.Add((line ?? int.MaxValue, node));
            }

            foreach (var group in interchange.FunctionalGroups)
                interchangeChildren.Add(BuildGroup(group, errorsByLine, lineToNode, Track));

            foreach (var child in interchangeChildren.OrderBy(c => c.LineNumber))
                interchangeNode.Children.Add(child.Node);
        }

        return (lineToNode, sources);
    }

    private static (int LineNumber, DocumentNodeViewModel Node) BuildGroup(
        x12FunctionalGroup group,
        IReadOnlyDictionary<int, List<Error>> errorsByLine,
        Dictionary<int, DocumentNodeViewModel> lineToNode,
        Action<ISourceTracked?> track)
    {
        DocumentNodeViewModel groupNode;
        int? groupLine;

        if (group.Header is not null)
        {
            track(group.Header);
            groupLine = group.Header.Source?.LineNumber;
            groupNode = new DocumentNodeViewModel(
                NodeKind.FunctionalGroup, "GS", "GS", GroupSubtitle(group.Header), groupLine, group.Header)
            {
                Elements = SegmentElementReader.Read(group.Header, "GS", ErrorsFor(errorsByLine, groupLine)),
            };
            if (groupLine is int gl)
                lineToNode[gl] = groupNode;
        }
        else
        {
            groupLine = group.Sections.Select(s => s.TransactionSetHeader?.Source?.LineNumber)
                .Concat(group.OrphanSegments.Select(o => o.Source?.LineNumber))
                .FirstOrDefault(l => l is not null);
            groupNode = new DocumentNodeViewModel(
                NodeKind.FunctionalGroup, "GS", "GS (missing)", "The GS record was not found", groupLine, null);
        }

        if (group.Trailer is not null)
        {
            track(group.Trailer);
            if (group.Trailer.Source?.LineNumber is int geLine)
                lineToNode[geLine] = groupNode;
        }

        var groupChildren = new List<(int LineNumber, DocumentNodeViewModel Node)>();

        foreach (var orphan in group.OrphanSegments)
        {
            track(orphan);
            var line = orphan.Source?.LineNumber;
            var node = BuildSegmentNode(orphan, line, ErrorsFor(errorsByLine, line), "(outside any transaction set) ");
            if (line is int ol)
                lineToNode[ol] = node;
            groupChildren.Add((line ?? int.MaxValue, node));
        }

        foreach (var section in group.Sections)
        {
            track(section.TransactionSetHeader);
            var stLine = section.TransactionSetHeader?.Source?.LineNumber;
            var title = TransactionSetTitle(section, group.Header?.VersionReleaseIndustryIdentifierCode);
            var subtitle = $"{section.TransactionSetControlNumber} · {section.Segments.Count} segments";
            var transactionSetNode = new DocumentNodeViewModel(
                NodeKind.TransactionSet, section.SectionType ?? "", title, subtitle, stLine, section)
            {
                Elements = section.TransactionSetHeader is not null
                    ? SegmentElementReader.Read(section.TransactionSetHeader, "ST", ErrorsFor(errorsByLine, stLine))
                    : Array.Empty<ElementViewModel>(),
            };
            if (stLine is int sl)
                lineToNode[sl] = transactionSetNode;

            if (section.TransactionSetTrailer is not null)
            {
                track(section.TransactionSetTrailer);
                if (section.TransactionSetTrailer.Source?.LineNumber is int seLine)
                    lineToNode[seLine] = transactionSetNode;
            }

            foreach (var segment in section.Segments)
            {
                track(segment);
                var segLine = segment.Source?.LineNumber;
                var segmentNode = BuildSegmentNode(segment, segLine, ErrorsFor(errorsByLine, segLine));
                if (segLine is int sgl)
                    lineToNode[sgl] = segmentNode;
                transactionSetNode.Children.Add(segmentNode);
            }

            groupChildren.Add((stLine ?? int.MaxValue, transactionSetNode));
        }

        foreach (var child in groupChildren.OrderBy(c => c.LineNumber))
            groupNode.Children.Add(child.Node);

        return (groupLine ?? int.MaxValue, groupNode);
    }

    private static string GetSegmentCode(object model) =>
        model.GetType().GetCustomAttribute<SegmentAttribute>()?.Name ?? model.GetType().Name;

    private static DocumentNodeViewModel BuildSegmentNode(
        EdiX12Segment segment, int? lineNumber, IReadOnlyList<Error> errors, string subtitlePrefix = "")
    {
        if (segment is Unknown_Segment unknown)
        {
            var elements = new List<ElementViewModel>(unknown.Elements.Count);
            for (var i = 0; i < unknown.Elements.Count; i++)
            {
                var position = i + 1;
                var reference = unknown.SegmentId + position.ToString("D2");
                var value = unknown.Elements[i];
                elements.Add(new ElementViewModel(
                    reference, position, $"Element {position}", $"Element{position}",
                    string.IsNullOrEmpty(value) ? null : value));
            }

            var unknownSubtitle = subtitlePrefix + string.Join(" ", unknown.Elements.Where(e => !string.IsNullOrEmpty(e)));
            return new DocumentNodeViewModel(
                NodeKind.Segment, unknown.SegmentId, $"{unknown.SegmentId} Unknown segment", unknownSubtitle, lineNumber, unknown)
            {
                Elements = elements,
            };
        }

        var code = GetSegmentCode(segment);
        var namePart = NamePartOf(segment.GetType().Name);
        var title = namePart.Length == 0 ? code : $"{code} {DisplayNames.SplitPascalCase(namePart)}";

        var segmentElements = SegmentElementReader.Read(segment, code, errors);
        var subtitle = subtitlePrefix + string.Join(" ", segmentElements.Where(e => e.HasValue).Select(e => e.Value).Take(3));

        return new DocumentNodeViewModel(NodeKind.Segment, code, title, subtitle, lineNumber, segment)
        {
            Elements = segmentElements,
        };
    }

    private static string NamePartOf(string typeName)
    {
        var underscoreIndex = typeName.IndexOf('_');
        return underscoreIndex >= 0 && underscoreIndex < typeName.Length - 1
            ? typeName[(underscoreIndex + 1)..]
            : "";
    }

    /// <summary>
    /// "ST 204" by default; "ST 204 Motor Carrier Load Tender" when a domain model assembly for this
    /// transaction set and version is loaded (Eddy.Notepad does not reference one itself, so this only
    /// takes effect if the host process loaded one).
    /// </summary>
    private static string TransactionSetTitle(Section section, string? version)
    {
        var code = section.SectionType ?? "";
        var baseTitle = $"ST {code}";
        if (string.IsNullOrEmpty(code))
            return baseTitle;

        var type = TransactionSetRegistry.Resolve(code, version);
        if (type is null)
            return baseTitle;

        var namePart = NamePartOf(type.Name);
        return namePart.Length == 0 ? baseTitle : $"{baseTitle} {DisplayNames.SplitPascalCase(namePart)}";
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

    private static string FormatOf(x12Document parsed)
    {
        var version = parsed.Interchanges
            .SelectMany(i => i.FunctionalGroups)
            .Select(g => g.Header?.VersionReleaseIndustryIdentifierCode)
            .FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));

        return string.IsNullOrWhiteSpace(version) ? "X12" : $"X12 {version}";
    }

    private static string BuildSummary(x12Document parsed, string format)
    {
        var interchangeCount = parsed.Interchanges.Count;
        var groupCount = parsed.Interchanges.Sum(i => i.FunctionalGroups.Count);
        var transactionSetCount = parsed.Interchanges.SelectMany(i => i.FunctionalGroups).Sum(g => g.Sections.Count);
        var errorCount = parsed.ValidationErrors.Sum(r => r.Errors.Count);

        return $"{format} · {interchangeCount} interchange{(interchangeCount == 1 ? "" : "s")} · " +
               $"{groupCount} group{(groupCount == 1 ? "" : "s")} · " +
               $"{transactionSetCount} transaction set{(transactionSetCount == 1 ? "" : "s")} · " +
               $"{errorCount} error{(errorCount == 1 ? "" : "s")}";
    }

    // ---- diagnostics --------------------------------------------------------------------------------------

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

    private static IReadOnlyList<Error> ErrorsFor(IReadOnlyDictionary<int, List<Error>> errorsByLine, int? lineNumber) =>
        lineNumber is int line && errorsByLine.TryGetValue(line, out var errors) ? errors : Array.Empty<Error>();

    private static void BuildDiagnostics(DocumentViewModel document, x12Document parsed, IReadOnlyList<RawLineViewModel> rawLines)
    {
        foreach (var result in parsed.ValidationErrors)
        {
            var lineNumber = result.LineNumber;
            var rawLine = rawLines.FirstOrDefault(r => r.LineNumber == lineNumber);
            var segmentCode = result.SegmentCode ?? SegmentCodeAt(rawLine);

            foreach (var error in result.Errors)
            {
                var diagnostic = new DiagnosticViewModel(
                    SeverityFor(error.ErrorCode),
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

    /// <summary>A missing trailer or a segment stranded outside a transaction set are warnings; everything else is an error.</summary>
    private static DiagnosticSeverity SeverityFor(ErrorCodes code) =>
        ReferenceEquals(code, ErrorCodes.MissingTrailer) || ReferenceEquals(code, ErrorCodes.SegmentOutsideTransactionSet)
            ? DiagnosticSeverity.Warning
            : DiagnosticSeverity.Error;

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
