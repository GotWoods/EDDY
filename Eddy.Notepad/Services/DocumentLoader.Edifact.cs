using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Edifact;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Services;

/// <summary>The EDIFACT half of the loader. Reads alike to DocumentLoader.X12.cs by design: same method
/// names and shapes, Eddy.Edifact model types in place of Eddy.x12 ones. See DocumentLoader.cs for the
/// shared pieces (raw lines from Source spans, diagnostics from ValidationResults, severity mapping,
/// summary wording).</summary>
public sealed partial class DocumentLoader
{
    private static DocumentViewModel LoadEdifact(string normalized, string displayName, string? filePath)
    {
        var parsed = EdiFactDocument.Parse(normalized, new EdifactParseOptions { Lenient = true });

        var format = FormatOf(parsed);
        var result = new DocumentViewModel(displayName, filePath, format, normalized);

        var errorsByLine = GroupErrorsByLine(parsed.ValidationErrors);
        var (lineToNode, sources) = BuildTree(result, parsed, errorsByLine);

        // Unlike x12Document, EdiFactDocument.Parse never leaves Interchanges partial in lenient mode: even
        // an unparseable UNB still gets an EdifactInterchange (with a null Header) so the rest of the file
        // keeps producing Source spans. So there is no "stopped early" case to fall back from here.
        result.RawLines = BuildRawLines(normalized, sources, stoppedEarly: false, lineToNode);

        BuildDiagnostics(result, parsed.ValidationErrors, EdifactWarningCodes, result.RawLines);
        result.Summary = BuildSummary(parsed, format);

        return result;
    }

    // ---- tree building ----------------------------------------------------------------------------------

    /// <summary>
    /// Builds one Interchange node per EdifactInterchange (Code "UNB"), one FunctionalGroup node per
    /// FunctionalGroup (Code "UNG"; a null Header is the implicit group used when the file has no UNG/UNE
    /// pair), one TransactionSet node per Message (Code = MessageType, title "UNH {MessageType}") and
    /// Segment nodes for its segments. Orphan segments become Segment nodes under their container, placed
    /// by line number among their siblings. UNT/UNE/UNZ trailers do not get their own nodes: their line
    /// number is mapped to the container node they close. The UNA line, when present, maps to the first
    /// Interchange node (there is exactly one ServiceStringAdvice per document). Returns the
    /// line-number-to-node map and every Source span found, for BuildRawLines.
    /// </summary>
    private static (Dictionary<int, DocumentNodeViewModel> LineToNode, List<(int LineNumber, string RawText)> Sources) BuildTree(
        DocumentViewModel document,
        EdiFactDocument parsed,
        IReadOnlyDictionary<int, List<Error>> errorsByLine)
    {
        var lineToNode = new Dictionary<int, DocumentNodeViewModel>();
        var sources = new List<(int LineNumber, string RawText)>();

        void Track(ISourceTracked? tracked)
        {
            if (tracked?.Source is { } src)
                sources.Add((src.LineNumber, src.RawText));
        }

        var isFirstInterchange = true;

        foreach (var interchange in parsed.Interchanges)
        {
            var unbLine = interchange.Header?.Source?.LineNumber;
            DocumentNodeViewModel interchangeNode;

            if (interchange.Header is not null)
            {
                Track(interchange.Header);
                interchangeNode = new DocumentNodeViewModel(
                    NodeKind.Interchange, "UNB", "UNB", InterchangeSubtitle(interchange.Header), unbLine, interchange.Header)
                {
                    Elements = SegmentElementReader.Read(interchange.Header, "UNB", ErrorsFor(errorsByLine, unbLine)),
                };
            }
            else
            {
                // Only happens when the UNB itself failed to parse in lenient mode: the interchange still
                // exists (so its content can be shown) but has no header to build a real node from.
                interchangeNode = new DocumentNodeViewModel(
                    NodeKind.Interchange, "UNB", "UNB (invalid)", "The UNB record could not be parsed", unbLine, null);
            }

            if (unbLine is int il)
                lineToNode[il] = interchangeNode;

            if (isFirstInterchange && parsed.ServiceStringAdvice is { Source: { } unaSource })
            {
                sources.Add((unaSource.LineNumber, unaSource.RawText));
                lineToNode[unaSource.LineNumber] = interchangeNode;
            }
            isFirstInterchange = false;

            document.Nodes.Add(interchangeNode);

            if (interchange.Trailer is not null)
            {
                Track(interchange.Trailer);
                if (interchange.Trailer.Source?.LineNumber is int unzLine)
                    lineToNode[unzLine] = interchangeNode;
            }

            var interchangeChildren = new List<(int LineNumber, DocumentNodeViewModel Node)>();

            foreach (var orphan in interchange.OrphanSegments)
            {
                Track(orphan);
                var line = orphan.Source?.LineNumber;
                var node = BuildSegmentNode(orphan, line, ErrorsFor(errorsByLine, line), "(outside any message) ");
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
        FunctionalGroup group,
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
                NodeKind.FunctionalGroup, "UNG", "UNG", GroupSubtitle(group.Header), groupLine, group.Header)
            {
                Elements = SegmentElementReader.Read(group.Header, "UNG", ErrorsFor(errorsByLine, groupLine)),
            };
            if (groupLine is int gl)
                lineToNode[gl] = groupNode;
        }
        else
        {
            // The implicit group used for messages that are not wrapped in an explicit UNG/UNE pair.
            groupLine = group.Messages.Select(m => m.Header?.Source?.LineNumber)
                .Concat(group.OrphanSegments.Select(o => o.Source?.LineNumber))
                .FirstOrDefault(l => l is not null);
            groupNode = new DocumentNodeViewModel(
                NodeKind.FunctionalGroup, "UNG", "Messages", "no UNG group header", groupLine, null);
        }

        if (group.Trailer is not null)
        {
            track(group.Trailer);
            if (group.Trailer.Source?.LineNumber is int uneLine)
                lineToNode[uneLine] = groupNode;
        }

        var groupChildren = new List<(int LineNumber, DocumentNodeViewModel Node)>();

        foreach (var orphan in group.OrphanSegments)
        {
            track(orphan);
            var line = orphan.Source?.LineNumber;
            var node = BuildSegmentNode(orphan, line, ErrorsFor(errorsByLine, line), "(outside any message) ");
            if (line is int ol)
                lineToNode[ol] = node;
            groupChildren.Add((line ?? int.MaxValue, node));
        }

        foreach (var message in group.Messages)
        {
            track(message.Header);
            var unhLine = message.Header?.Source?.LineNumber;
            var code = message.MessageType ?? "";
            var title = code.Length == 0 ? "UNH" : $"UNH {code}";
            var subtitle = $"{message.Header?.MessageReferenceNumber} · {message.Version} · {message.Segments.Count} segments";
            var messageNode = new DocumentNodeViewModel(NodeKind.TransactionSet, code, title, subtitle, unhLine, message)
            {
                Elements = message.Header is not null
                    ? SegmentElementReader.Read(message.Header, "UNH", ErrorsFor(errorsByLine, unhLine))
                    : Array.Empty<ElementViewModel>(),
            };
            if (unhLine is int hl)
                lineToNode[hl] = messageNode;

            if (message.Trailer is not null)
            {
                track(message.Trailer);
                if (message.Trailer.Source?.LineNumber is int untLine)
                    lineToNode[untLine] = messageNode;
            }

            foreach (var segment in message.Segments)
            {
                track(segment);
                var segLine = segment.Source?.LineNumber;
                var segmentNode = BuildSegmentNode(segment, segLine, ErrorsFor(errorsByLine, segLine));
                if (segLine is int sgl)
                    lineToNode[sgl] = segmentNode;
                messageNode.Children.Add(segmentNode);
            }

            groupChildren.Add((unhLine ?? int.MaxValue, messageNode));
        }

        foreach (var child in groupChildren.OrderBy(c => c.LineNumber))
            groupNode.Children.Add(child.Node);

        return (groupLine ?? int.MaxValue, groupNode);
    }

    private static DocumentNodeViewModel BuildSegmentNode(
        EdifactSegment segment, int? lineNumber, IReadOnlyList<Error> errors, string subtitlePrefix = "")
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

    private static string InterchangeSubtitle(GenericInterchangeControlHeader header)
    {
        var control = header.InterchangeControlReference ?? "";
        var sender = (header.InterchangeSender?.InterchangeSenderIdentification ?? "").Trim();
        var receiver = (header.InterchangeRecipient?.InterchangeRecipientIdentification ?? "").Trim();
        var date = header.DateAndTimeOfPreparation?.Date ?? "";

        return $"{control} · {sender} -> {receiver} · {date}";
    }

    private static string GroupSubtitle(GenericFunctionalGroupHeader header)
    {
        var sender = (header.ApplicationSendersIdentification?.SenderIdentification ?? "").Trim();
        var receiver = (header.ApplicationRecipientsIdentification?.RecipientsIdentification ?? "").Trim();
        var version = (header.MessageVersion?.MessageVersionNumber ?? "") + (header.MessageVersion?.MessageReleaseNumber ?? "");
        return $"{header.FunctionalGroupIdentification} · {sender} -> {receiver} · {version}";
    }

    /// <summary>"EDIFACT D96A" style, using the first message's declared standards version; plain "EDIFACT"
    /// when no message was found to read a version from.</summary>
    private static string FormatOf(EdiFactDocument parsed)
    {
        var version = parsed.Interchanges
            .SelectMany(i => i.FunctionalGroups)
            .SelectMany(g => g.Messages)
            .Select(m => m.Version)
            .FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));

        return string.IsNullOrWhiteSpace(version) ? "EDIFACT" : $"EDIFACT {version}";
    }

    private static string BuildSummary(EdiFactDocument parsed, string format)
    {
        var interchangeCount = parsed.Interchanges.Count;
        var groupCount = parsed.Interchanges.Sum(i => i.FunctionalGroups.Count);
        var messageCount = parsed.Interchanges.SelectMany(i => i.FunctionalGroups).Sum(g => g.Messages.Count);
        var errorCount = parsed.ValidationErrors.Sum(r => r.Errors.Count);

        return BuildEnvelopeSummary(format, interchangeCount, groupCount, messageCount, "message", errorCount);
    }
}
