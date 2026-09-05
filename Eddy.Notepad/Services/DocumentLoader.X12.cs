using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Notepad.ViewModels;
using Eddy.x12;
using Eddy.x12.Models;

namespace Eddy.Notepad.Services;

/// <summary>The X12 half of the loader. See DocumentLoader.cs for the shared pieces and DocumentLoader.Edifact.cs
/// for the EDIFACT half, which reads alike by design.</summary>
public sealed partial class DocumentLoader
{
    private DocumentViewModel LoadX12(string normalized, string displayName, string? filePath)
    {
        // Must run before anything below consults TransactionSetRegistry (the title-building code just a
        // few lines down included) -- see LoopViewBuilder's class remarks.
        LoopViewBuilder.EnsureAssembliesLoaded();

        var parsed = x12Document.Parse(normalized, new x12ParseOptions { Lenient = true, CodeListChecking = CodeListChecking.Warn });

        var format = FormatOf(parsed);
        var result = new DocumentViewModel(displayName, filePath, format, normalized);

        var errorsByLine = GroupErrorsByLine(parsed.ValidationErrors);
        var (lineToNode, sources) = BuildTree(result, parsed, errorsByLine);

        // A bad ISA is the only thing that stops the parser outright (InvalidInterchangeHeader), possibly
        // leaving Interchanges empty (the file's very first ISA was bad) or partial (a later one was, in a
        // multi-interchange file). Either way the parser produced no Source spans for whatever comes after
        // the failure point, so fall back to a plain text split to keep the raw view showing the whole file.
        var stoppedEarly = parsed.ValidationErrors.Any(r => r.Errors.Any(e => ReferenceEquals(e.ErrorCode, ErrorCodes.InvalidInterchangeHeader)));
        result.RawLines = BuildRawLines(normalized, sources, stoppedEarly, lineToNode);

        BuildDiagnostics(result, parsed.ValidationErrors, X12WarningCodes, result.RawLines);
        result.Summary = BuildSummary(parsed, format);

        return result;
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
    private (Dictionary<int, DocumentNodeViewModel> LineToNode, List<(int LineNumber, string RawText)> Sources) BuildTree(
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
                Elements = _reader.Read(interchange.Header, "ISA", ErrorsFor(errorsByLine, isaLine)),
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
                interchangeChildren.Add(BuildGroup(document, group, errorsByLine, lineToNode, Track));

            foreach (var child in interchangeChildren.OrderBy(c => c.LineNumber))
                interchangeNode.Children.Add(child.Node);
        }

        return (lineToNode, sources);
    }

    private (int LineNumber, DocumentNodeViewModel Node) BuildGroup(
        DocumentViewModel document,
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
                Elements = _reader.Read(group.Header, "GS", ErrorsFor(errorsByLine, groupLine)),
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
            var code = section.SectionType ?? "";
            var version = group.Header?.VersionReleaseIndustryIdentifierCode;
            var domainType = TransactionSetRegistry.Resolve(code, version ?? "");
            var title = TransactionSetTitle(code, domainType);
            var subtitle = TransactionSetSubtitle(section, code, version, domainType);
            var transactionSetNode = new DocumentNodeViewModel(
                NodeKind.TransactionSet, code, title, subtitle, stLine, section)
            {
                Elements = section.TransactionSetHeader is not null
                    ? _reader.Read(section.TransactionSetHeader, "ST", ErrorsFor(errorsByLine, stLine))
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

            var segmentNodes = new Dictionary<EdiX12Segment, DocumentNodeViewModel>();
            foreach (var segment in section.Segments)
            {
                track(segment);
                var segLine = segment.Source?.LineNumber;
                var segmentNode = BuildSegmentNode(segment, segLine, ErrorsFor(errorsByLine, segLine));
                if (segLine is int sgl)
                    lineToNode[sgl] = segmentNode;
                transactionSetNode.Children.Add(segmentNode);
                segmentNodes[segment] = segmentNode;
            }

            transactionSetNode.HasLoopView = domainType is not null;
            if (domainType is not null)
            {
                var loopChildren = LoopViewBuilder.Build(domainType, code, section.Segments, segmentNodes, document.Diagnostics);
                foreach (var child in loopChildren)
                    transactionSetNode.LoopChildren.Add(child);
            }

            groupChildren.Add((stLine ?? int.MaxValue, transactionSetNode));
        }

        foreach (var child in groupChildren.OrderBy(c => c.LineNumber))
            groupNode.Children.Add(child.Node);

        return (groupLine ?? int.MaxValue, groupNode);
    }

    private DocumentNodeViewModel BuildSegmentNode(
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

        var segmentElements = _reader.Read(segment, code, errors);
        var subtitle = subtitlePrefix + string.Join(" ", segmentElements.Where(e => e.HasValue).Select(e => e.Value).Take(3));

        return new DocumentNodeViewModel(NodeKind.Segment, code, title, subtitle, lineNumber, segment)
        {
            Elements = segmentElements,
        };
    }

    /// <summary>
    /// "ST 204" by default; "ST 204 Motor Carrier Load Tender" when <paramref name="domainType"/> resolved
    /// (Eddy.x12.DomainModels.Transportation and .CommunicationsAndControls are the only domain model
    /// assemblies Eddy.Notepad references; see README.md, "Dependencies").
    /// </summary>
    private static string TransactionSetTitle(string code, Type? domainType)
    {
        var baseTitle = $"ST {code}";
        if (string.IsNullOrEmpty(code) || domainType is null)
            return baseTitle;

        var namePart = NamePartOf(domainType.Name);
        return namePart.Length == 0 ? baseTitle : $"{baseTitle} {DisplayNames.SplitPascalCase(namePart)}";
    }

    /// <summary>"0001 · 14 segments" by default, plus " · no loop model for 204 004010" when no domain
    /// model resolved for this transaction set's code and version -- see Services/LoopViewBuilder.cs.</summary>
    private static string TransactionSetSubtitle(Section section, string code, string? version, Type? domainType)
    {
        var subtitle = $"{section.TransactionSetControlNumber} · {section.Segments.Count} segments";
        if (domainType is null && !string.IsNullOrEmpty(code))
            subtitle += $" · no loop model for {code} {version}";
        return subtitle;
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

        return BuildEnvelopeSummary(format, interchangeCount, groupCount, transactionSetCount, "transaction set", errorCount);
    }
}
