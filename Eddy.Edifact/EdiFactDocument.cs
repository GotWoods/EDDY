using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;

namespace Eddy.Edifact;

public class Message
{
    public GenericMessageHeader Header { get; set; }
    public GenericMessageTrailer Trailer { get; set; }
    public List<EdifactSegment> Segments { get; set; } = new List<EdifactSegment>();

    /// <summary>Convenience accessor for the message type from the UNH S009 composite, e.g. "APERAK".</summary>
    public string MessageType => Header?.MessageIdentifier?.MessageType;

    /// <summary>Convenience accessor for the message's standards version, e.g. "D96A".</summary>
    public string Version => Header?.Version;
}

public class FunctionalGroup
{
    /// <summary>UNG header, or null when this group is the implicit container used for messages that
    /// are not wrapped in an explicit UNG/UNE pair.</summary>
    public GenericFunctionalGroupHeader Header { get; set; }
    public GenericFunctionalGroupTrailer Trailer { get; set; }
    public List<Message> Messages { get; set; } = new List<Message>();

    /// <summary>Segments encountered while this group was open but outside of any UNH/UNT message.</summary>
    public List<EdifactSegment> OrphanSegments { get; set; } = new List<EdifactSegment>();
}

public class EdifactInterchange
{
    public GenericInterchangeControlHeader Header { get; set; }

    /// <summary>UNZ trailer, or null when the interchange was never closed (missing trailer).</summary>
    public GenericInterchangeControlTrailer Trailer { get; set; }
    public List<FunctionalGroup> FunctionalGroups { get; set; } = new List<FunctionalGroup>();

    /// <summary>Segments encountered while this interchange was open but outside of any functional
    /// group and outside of any UNH/UNT message.</summary>
    public List<EdifactSegment> OrphanSegments { get; set; } = new List<EdifactSegment>();
}

public class EdiFactDocument
{
    /// <summary>The UNA service string advice, when the input had one; otherwise null (defaults applied).</summary>
    public ServiceStringAdvice ServiceStringAdvice { get; set; }

    /// <summary>The first interchange's header, kept for callers written against the single-interchange
    /// shape this type used to have. Prefer <see cref="Interchanges"/> for documents that may hold more
    /// than one UNB...UNZ interchange.</summary>
    public GenericInterchangeControlHeader InterchangeControlHeader { get; set; }

    /// <summary>The first interchange's functional groups, kept for the same reason as
    /// <see cref="InterchangeControlHeader"/>. Prefer <see cref="Interchanges"/>.</summary>
    public List<FunctionalGroup> FunctionalGroups { get; set; } = new List<FunctionalGroup>();

    /// <summary>Every UNB...UNZ interchange found in the input, in file order.</summary>
    public List<EdifactInterchange> Interchanges { get; set; } = new List<EdifactInterchange>();

    public List<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();

    public bool IsValid => !ValidationErrors.Any();

    private static readonly Regex VersionPattern = new Regex(@"^D(\d{2})([A-Za-z])$", RegexOptions.Compiled);

    private static readonly Lazy<List<string>> _availableVersions =
        new Lazy<List<string>>(LoadAvailableVersions, LazyThreadSafetyMode.ExecutionAndPublication);

    public static EdiFactDocument Parse(string data)
    {
        return Parse(data, new EdifactParseOptions());
    }

    public static EdiFactDocument Parse(string data, EdifactParseOptions parseOptions)
    {
        parseOptions = parseOptions ?? new EdifactParseOptions();
        var document = new EdiFactDocument();

        if (string.IsNullOrEmpty(data))
            return document;

        //What is UNS used for?
        /*
         * UNA (optional service string advice - defines the delimiters used by the rest of the file)
         * UNB (Mandatory Interchange Control Header. Contains sender/recipient/time/control number)
         *  UNG  (Optional Group)
         *      UNH (Mandatory Message Header. Contains type (e.g. APERAK) as well as version like D00A)
         *          Data here
         *      UNT
         *  UNE (Group trailer)
         * UNZ (Interchange Control Trailer)
         * A file may contain more than one UNB...UNZ interchange, one after another.
         */

        var options = new MapOptions();
        var scanStart = 0;
        while (scanStart < data.Length && IsWhitespace(data[scanStart]))
            scanStart++;

        var startLineNumber = 1;
        if (scanStart + 3 <= data.Length && string.Compare(data, scanStart, "UNA", 0, 3, StringComparison.OrdinalIgnoreCase) == 0)
        {
            if (scanStart + 9 > data.Length)
                throw new InvalidFileFormatException("UNA service string advice is truncated");

            var advice = new ServiceStringAdvice(data[scanStart + 3], data[scanStart + 4], data[scanStart + 5],
                data[scanStart + 6], data[scanStart + 7], data[scanStart + 8]);
            advice.Source = new SegmentSource(1, scanStart, 9, data.Substring(scanStart, 9));
            document.ServiceStringAdvice = advice;

            options.ComponentElementSeparator = advice.ComponentDataElementSeparator.ToString();
            options.Separator = advice.DataElementSeparator.ToString();
            options.DecimalMark = advice.DecimalMark.ToString();
            options.ReleaseCharacter = advice.ReleaseCharacter.ToString();
            options.RepetitionSeparator = advice.RepetitionSeparator.ToString();
            options.LineEnding = advice.SegmentTerminator.ToString();

            scanStart += 9;
            startLineNumber = 2;
        }

        var releaseChar = options.ReleaseCharacter[0];
        var terminatorChar = options.LineEnding[0];

        var rawSegments = ScanSegments(data, scanStart, terminatorChar, releaseChar, startLineNumber);

        EdifactInterchange currentInterchange = null;
        FunctionalGroup currentGroup = null;
        Message currentMessage = null;
        GenericMessageHeader currentMessageHeader = null;
        string currentMessageVersion = null;
        var segmentsInMessage = 0;

        foreach (var rawSeg in rawSegments)
        {
            var source = new SegmentSource(rawSeg.LineNumber, rawSeg.StartOffset, rawSeg.Length, rawSeg.RawText);
            var tag = GetSegmentTag(rawSeg.RawText, options);

            if (tag == "UNA") //already handled above; guard against a stray duplicate
            {
                continue;
            }
            else if (tag == "UNB")
            {
                if (currentInterchange != null && currentInterchange.Trailer == null)
                    ReportMissingTrailer(document, parseOptions, "UNZ", "interchange", currentInterchange.Header?.Source ?? source);

                var header = TryMapStructural<GenericInterchangeControlHeader>(rawSeg, options, parseOptions, document, source, "UNB");
                currentInterchange = new EdifactInterchange { Header = header };
                document.Interchanges.Add(currentInterchange);
                currentGroup = null;
                currentMessage = null;
                currentMessageHeader = null;
                currentMessageVersion = null;
            }
            else if (tag == "UNG")
            {
                var header = TryMapStructural<GenericFunctionalGroupHeader>(rawSeg, options, parseOptions, document, source, "UNG");
                currentGroup = new FunctionalGroup { Header = header };
                currentInterchange?.FunctionalGroups.Add(currentGroup);
            }
            else if (tag == "UNH")
            {
                var header = TryMapStructural<GenericMessageHeader>(rawSeg, options, parseOptions, document, source, "UNH");
                if (header != null)
                {
                    if (currentGroup == null)
                    {
                        currentGroup = new FunctionalGroup(); //implicit group - no UNG in the file
                        currentInterchange?.FunctionalGroups.Add(currentGroup);
                    }

                    var message = new Message { Header = header };
                    currentGroup.Messages.Add(message);
                    currentMessage = message;
                    currentMessageHeader = header;

                    var requestedVersion = header.Version;
                    var resolvedVersion = ResolveVersion(requestedVersion, out var usedFallback);
                    currentMessageVersion = resolvedVersion;
                    if (usedFallback)
                        AddValidationError(document, ErrorCodes.EdiFactUnsupportedVersion,
                            new[] { requestedVersion, resolvedVersion }, source, "UNH");

                    segmentsInMessage = 1; //UNH itself
                }
            }
            else if (tag == "UNT")
            {
                if (currentMessage == null)
                {
                    ReportUnexpectedTrailer(document, parseOptions, "UNT", source);
                }
                else
                {
                    var trailer = TryMapStructural<GenericMessageTrailer>(rawSeg, options, parseOptions, document, source, "UNT");
                    if (trailer != null)
                    {
                        currentMessage.Trailer = trailer;
                        segmentsInMessage++; //UNT itself

                        if (int.TryParse(trailer.NumberOfSegmentsInMessage, out var declaredCount) && declaredCount != segmentsInMessage)
                            AddValidationError(document, ErrorCodes.EdiFactMessageSegmentCountMismatch,
                                new[] { trailer.NumberOfSegmentsInMessage, segmentsInMessage.ToString() }, source, "UNT");

                        if (currentMessageHeader != null && trailer.MessageReferenceNumber != currentMessageHeader.MessageReferenceNumber)
                            AddValidationError(document, ErrorCodes.EdiFactMessageReferenceMismatch,
                                new[] { currentMessageHeader.MessageReferenceNumber, trailer.MessageReferenceNumber }, source, "UNT");
                    }

                    currentMessage = null;
                    currentMessageHeader = null;
                    currentMessageVersion = null;
                }
            }
            else if (tag == "UNE")
            {
                if (currentGroup == null || currentGroup.Header == null)
                {
                    ReportUnexpectedTrailer(document, parseOptions, "UNE", source);
                    currentGroup = null;
                }
                else
                {
                    var trailer = TryMapStructural<GenericFunctionalGroupTrailer>(rawSeg, options, parseOptions, document, source, "UNE");
                    if (trailer != null)
                    {
                        currentGroup.Trailer = trailer;

                        if (int.TryParse(trailer.NumberOfMessages, out var declaredCount) && declaredCount != currentGroup.Messages.Count)
                            AddValidationError(document, ErrorCodes.EdiFactFunctionalGroupSectionCountMismatch,
                                new[] { trailer.NumberOfMessages, currentGroup.Messages.Count.ToString() }, source, "UNE");

                        if (trailer.FunctionalGroupReferenceNumber != currentGroup.Header.FunctionalGroupReferenceNumber)
                            AddValidationError(document, ErrorCodes.EdiFactFunctionalGroupControlNumberMismatch,
                                new[] { currentGroup.Header.FunctionalGroupReferenceNumber, trailer.FunctionalGroupReferenceNumber }, source, "UNE");
                    }

                    currentGroup = null;
                }
            }
            else if (tag == "UNZ")
            {
                if (currentInterchange == null)
                {
                    ReportUnexpectedTrailer(document, parseOptions, "UNZ", source);
                }
                else
                {
                    var trailer = TryMapStructural<GenericInterchangeControlTrailer>(rawSeg, options, parseOptions, document, source, "UNZ");
                    if (trailer != null)
                    {
                        currentInterchange.Trailer = trailer;

                        var explicitGroupCount = currentInterchange.FunctionalGroups.Count(g => g.Header != null);
                        var expectedCount = explicitGroupCount > 0
                            ? explicitGroupCount
                            : currentInterchange.FunctionalGroups.Sum(g => g.Messages.Count);

                        if (int.TryParse(trailer.InterchangeControlCount, out var declaredCount) && declaredCount != expectedCount)
                            AddValidationError(document, ErrorCodes.EdiFactInterchangeMessageCountMismatch,
                                new[] { trailer.InterchangeControlCount, expectedCount.ToString() }, source, "UNZ");

                        if (currentInterchange.Header != null && trailer.InterchangeControlReference != currentInterchange.Header.InterchangeControlReference)
                            AddValidationError(document, ErrorCodes.EdiFactInterchangeControlReferenceMismatch,
                                new[] { currentInterchange.Header.InterchangeControlReference, trailer.InterchangeControlReference }, source, "UNZ");
                    }

                    currentInterchange = null;
                    currentGroup = null;
                    currentMessage = null;
                }
            }
            else if (currentMessage != null) //ordinary content segment inside a message
            {
                EdifactSegment segment;
                var segmentType = EdiSectionParserFactory.GetSegmentFor(currentMessageVersion, tag);
                if (segmentType == null)
                {
                    if (!parseOptions.Lenient)
                        throw new InvalidFileFormatException(
                            $"Segment '{tag}' is not defined in version {currentMessageVersion} (line {source.LineNumber})");

                    segment = new Unknown_Segment
                    {
                        SegmentId = tag,
                        Version = currentMessageVersion,
                        Elements = Map.SplitElements(rawSeg.RawText, options).Skip(1).ToList()
                    };
                }
                else
                {
                    try
                    {
                        segment = (EdifactSegment)Map.MapObject(segmentType, rawSeg.RawText, options);
                    }
                    catch (Exception ex)
                    {
                        if (!parseOptions.Lenient)
                            throw new InvalidFileFormatException(
                                $"Segment '{tag}' could not be parsed: {ex.Message} (line {source.LineNumber})");

                        AddValidationError(document, ErrorCodes.EdiFactSegmentParseFailure, new[] { tag, ex.Message }, source, tag);
                        segment = null;
                    }
                }

                if (segment != null)
                {
                    segment.Source = source;
                    currentMessage.Segments.Add(segment);

                    var validationResult = segment.Validate();
                    if (!validationResult.IsValid)
                    {
                        validationResult.LineNumber = source.LineNumber;
                        validationResult.Source = source;
                        document.ValidationErrors.Add(validationResult);
                    }
                }

                segmentsInMessage++;
            }
            else //segment outside of any UNH/UNT message
            {
                if (!parseOptions.Lenient)
                    throw new InvalidFileFormatException(
                        $"Segment '{tag}' appeared outside of a UNH/UNT message (line {source.LineNumber})");

                var orphan = new Unknown_Segment
                {
                    SegmentId = tag,
                    Elements = Map.SplitElements(rawSeg.RawText, options).Skip(1).ToList()
                };
                orphan.Source = source;

                var target = currentGroup != null ? currentGroup.OrphanSegments : currentInterchange?.OrphanSegments;
                target?.Add(orphan);

                AddValidationError(document, ErrorCodes.EdiFactSegmentOutsideMessage, new[] { tag }, source, tag);
            }
        }

        if (currentMessage != null)
            ReportMissingTrailer(document, parseOptions, "UNT", "message", currentMessageHeader?.Source);
        if (currentGroup != null && currentGroup.Header != null && currentGroup.Trailer == null)
            ReportMissingTrailer(document, parseOptions, "UNE", "functional group", currentGroup.Header.Source);
        if (currentInterchange != null && currentInterchange.Trailer == null)
            ReportMissingTrailer(document, parseOptions, "UNZ", "interchange", currentInterchange.Header?.Source);

        if (document.Interchanges.Count > 0)
        {
            document.InterchangeControlHeader = document.Interchanges[0].Header;
            document.FunctionalGroups = document.Interchanges[0].FunctionalGroups;
        }

        return document;
    }

    public string ToString(MapOptions options)
    {
        options = options ?? new MapOptions();
        var defaults = new MapOptions();
        var sb = new StringBuilder();

        var optionsDiffer = options.ComponentElementSeparator != defaults.ComponentElementSeparator
            || options.Separator != defaults.Separator
            || options.DecimalMark != defaults.DecimalMark
            || options.ReleaseCharacter != defaults.ReleaseCharacter
            || options.RepetitionSeparator != defaults.RepetitionSeparator
            || options.LineEnding != defaults.LineEnding;

        if (ServiceStringAdvice != null || optionsDiffer)
        {
            var advice = new ServiceStringAdvice(options.ComponentElementSeparator[0], options.Separator[0],
                options.DecimalMark[0], options.ReleaseCharacter[0], options.RepetitionSeparator[0], options.LineEnding[0]);
            sb.Append(advice.ToString());
        }

        foreach (var interchange in Interchanges)
        {
            if (interchange.Header != null)
                sb.Append(WriteSegment(interchange.Header, options));

            var explicitGroupCount = 0;
            var totalMessages = 0;

            foreach (var group in interchange.FunctionalGroups)
            {
                if (group.Header != null)
                {
                    sb.Append(WriteSegment(group.Header, options));
                    explicitGroupCount++;
                }

                var messagesInGroup = 0;
                foreach (var message in group.Messages)
                {
                    if (message.Header != null)
                        sb.Append(WriteSegment(message.Header, options));

                    foreach (var segment in message.Segments)
                        if (segment != null)
                            sb.Append(WriteSegment(segment, options));

                    var trailer = new GenericMessageTrailer
                    {
                        NumberOfSegmentsInMessage = (message.Segments.Count + 2).ToString(),
                        MessageReferenceNumber = message.Header?.MessageReferenceNumber
                    };
                    sb.Append(WriteSegment(trailer, options));

                    messagesInGroup++;
                    totalMessages++;
                }

                foreach (var orphan in group.OrphanSegments)
                    if (orphan != null)
                        sb.Append(WriteSegment(orphan, options));

                if (group.Header != null)
                {
                    var groupTrailer = new GenericFunctionalGroupTrailer
                    {
                        NumberOfMessages = messagesInGroup.ToString(),
                        FunctionalGroupReferenceNumber = group.Header.FunctionalGroupReferenceNumber
                    };
                    sb.Append(WriteSegment(groupTrailer, options));
                }
            }

            foreach (var orphan in interchange.OrphanSegments)
                if (orphan != null)
                    sb.Append(WriteSegment(orphan, options));

            if (interchange.Header != null)
            {
                var unzCount = explicitGroupCount > 0 ? explicitGroupCount : totalMessages;
                var trailer = new GenericInterchangeControlTrailer
                {
                    InterchangeControlCount = unzCount.ToString(),
                    InterchangeControlReference = interchange.Header.InterchangeControlReference
                };
                sb.Append(WriteSegment(trailer, options));
            }
        }

        return sb.ToString();
    }

    private static string WriteSegment(EdifactSegment segment, MapOptions options)
    {
        if (segment == null)
            return "";

        if (segment is Unknown_Segment unknown)
        {
            var sb = new StringBuilder(unknown.SegmentId);
            foreach (var element in unknown.Elements)
            {
                sb.Append(options.Separator);
                sb.Append(Map.EscapeValue(element, options));
            }
            sb.Append(options.LineEnding);
            return sb.ToString();
        }

        return Map.SegmentToString(segment, options);
    }

    private static void ReportUnexpectedTrailer(EdiFactDocument document, EdifactParseOptions parseOptions, string tag, SegmentSource source)
    {
        if (!parseOptions.Lenient)
            throw new InvalidFileFormatException($"Trailer '{tag}' appeared without a matching header (line {source.LineNumber})");

        AddValidationError(document, ErrorCodes.EdiFactUnexpectedTrailer, new[] { tag }, source, tag);
    }

    private static void ReportMissingTrailer(EdiFactDocument document, EdifactParseOptions parseOptions, string expectedTag, string container, SegmentSource headerSource)
    {
        if (!parseOptions.Lenient)
            throw new InvalidFileFormatException($"Expected trailer '{expectedTag}' for {container} was not found");

        AddValidationError(document, ErrorCodes.EdiFactMissingTrailer, new[] { expectedTag, container }, headerSource, container == "interchange" ? "UNB" : container == "functional group" ? "UNG" : "UNH");
    }

    private static void AddValidationError(EdiFactDocument document, ErrorCodes code, string[] data, SegmentSource source, string segmentCode)
    {
        var vr = new ValidationResult { LineNumber = source?.LineNumber ?? 0, Source = source, SegmentCode = segmentCode };
        vr.Add(new Error(code, data));
        document.ValidationErrors.Add(vr);
    }

    private static T TryMapStructural<T>(RawSegment rawSeg, MapOptions options, EdifactParseOptions parseOptions, EdiFactDocument document, SegmentSource source, string tag)
        where T : EdifactSegment, new()
    {
        T result;
        try
        {
            result = Map.MapObject<T>(rawSeg.RawText, options);
        }
        catch (Exception ex)
        {
            if (!parseOptions.Lenient)
                throw new InvalidFileFormatException($"Segment '{tag}' could not be parsed: {ex.Message} (line {source.LineNumber})");

            AddValidationError(document, ErrorCodes.EdiFactSegmentParseFailure, new[] { tag, ex.Message }, source, tag);
            return null;
        }

        result.Source = source;

        var validationResult = result.Validate();
        if (!validationResult.IsValid)
        {
            validationResult.LineNumber = source.LineNumber;
            validationResult.Source = source;
            document.ValidationErrors.Add(validationResult);
        }

        return result;
    }

    private static string GetSegmentTag(string rawText, MapOptions options)
    {
        var idx = rawText.IndexOf(options.Separator, StringComparison.Ordinal);
        return idx == -1 ? rawText : rawText.Substring(0, idx);
    }

    private static bool IsWhitespace(char c)
    {
        return c == ' ' || c == '\t' || c == '\r' || c == '\n';
    }

    /// <summary>A segment's raw, still-escaped text and its position in the original input.</summary>
    private class RawSegment
    {
        public int LineNumber;
        public int StartOffset;
        public int Length;
        public string RawText;
    }

    /// <summary>Scans <paramref name="data"/> for segments starting at <paramref name="startOffset"/>,
    /// honouring the release character (a terminator immediately preceded by it does not end the
    /// segment). Does not normalize newlines first - \r, \n, tabs and spaces around a segment are
    /// treated as whitespace and excluded from its recorded span. Blank segments (consecutive
    /// terminators, trailing whitespace) are skipped and do not consume a line number.</summary>
    private static List<RawSegment> ScanSegments(string data, int startOffset, char terminator, char releaseChar, int startLineNumber)
    {
        var result = new List<RawSegment>();
        var i = startOffset;
        var lineNumber = startLineNumber;

        while (i < data.Length)
        {
            while (i < data.Length && IsWhitespace(data[i]))
                i++;
            if (i >= data.Length)
                break;

            var contentStart = i;
            while (i < data.Length)
            {
                if (data[i] == releaseChar && i + 1 < data.Length)
                {
                    i += 2;
                    continue;
                }
                if (data[i] == terminator)
                    break;
                i++;
            }

            var segmentEnd = i; //index of the terminator, or data.Length if none was found
            var contentEnd = segmentEnd;
            while (contentEnd > contentStart && IsWhitespace(data[contentEnd - 1]))
                contentEnd--;

            if (contentEnd > contentStart)
            {
                result.Add(new RawSegment
                {
                    LineNumber = lineNumber,
                    StartOffset = contentStart,
                    Length = contentEnd - contentStart,
                    RawText = data.Substring(contentStart, contentEnd - contentStart)
                });
                lineNumber++;
            }

            if (i < data.Length && data[i] == terminator)
                i++; //consume the terminator
            else
                break; //reached end of input without a terminator
        }

        return result;
    }

    private static List<string> LoadAvailableVersions()
    {
        var prefix = typeof(EdiFactDocument).Namespace + ".Models.";
        return typeof(EdiFactDocument).Assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.StartsWith(prefix, StringComparison.Ordinal))
            .Select(t => t.Namespace.Substring(prefix.Length).Split('.')[0])
            .Distinct()
            .Where(v => VersionPattern.IsMatch(v))
            .OrderBy(v => VersionSortKey(v))
            .ToList();
    }

    private static int? VersionSortKey(string version)
    {
        if (string.IsNullOrEmpty(version))
            return null;

        var m = VersionPattern.Match(version);
        if (!m.Success)
            return null;

        var yy = int.Parse(m.Groups[1].Value);
        var actualYear = yy >= 90 ? 1900 + yy : 2000 + yy; //D96A..D99B are 1996-1999, D00A.. are 2000+
        var letterOffset = char.ToUpperInvariant(m.Groups[2].Value[0]) - 'A';
        return actualYear * 100 + letterOffset;
    }

    /// <summary>Resolves a message's declared version (e.g. "D96A") to one this library actually has
    /// models for. When the declared version is not available, prefers the closest lower version, then
    /// the closest higher one, and reports the fallback through <paramref name="usedFallback"/>.</summary>
    private static string ResolveVersion(string requestedVersion, out bool usedFallback)
    {
        usedFallback = false;
        var available = _availableVersions.Value;

        if (!string.IsNullOrEmpty(requestedVersion) && available.Contains(requestedVersion))
            return requestedVersion;

        usedFallback = true;
        if (available.Count == 0)
            return requestedVersion ?? "";

        var targetKey = VersionSortKey(requestedVersion);
        if (targetKey == null)
            return available[0];

        string bestLower = null;
        var bestLowerKey = int.MinValue;
        string bestHigher = null;
        var bestHigherKey = int.MaxValue;

        foreach (var v in available)
        {
            var k = VersionSortKey(v) ?? int.MinValue;
            if (k <= targetKey.Value && k > bestLowerKey)
            {
                bestLowerKey = k;
                bestLower = v;
            }
            if (k > targetKey.Value && k < bestHigherKey)
            {
                bestHigherKey = k;
                bestHigher = v;
            }
        }

        return bestLower ?? bestHigher ?? available[0];
    }
}
