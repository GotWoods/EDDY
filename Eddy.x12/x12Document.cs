using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

using SE_TransactionSetTrailer = Eddy.x12.Models.SE_TransactionSetTrailer;
using ST_TransactionSetHeader = Eddy.x12.Models.ST_TransactionSetHeader;

namespace Eddy.x12;

public class x12Document
{
    // Legacy properties. After Parse() these mirror the first interchange/group and the flattened list of
    // every Section in the document (in file order), so existing callers built against the single-group
    // model keep working. They remain settable so hand-built documents (constructed and then ToString()'d)
    // still work exactly as before.
    public GenericInterchangeControlHeader InterchangeControlHeader { get; set; }
    public GenericFunctionalGroupHeader GsHeader { get; set; }
    public List<Section> Sections { get; set; } = new();

    public List<ValidationResult> ValidationErrors { get; set; } = new();
    public bool IsValid => !ValidationErrors.Any();

    /// <summary>Every ISA...IEA interchange found in the document, in file order. A file can contain several.</summary>
    public List<x12Interchange> Interchanges { get; set; } = new();

    /// <summary>The MapOptions the first interchange was parsed with (see <see cref="x12Interchange.MapOptions"/>).</summary>
    public MapOptions MapOptions { get; set; }

    public string ToString(MapOptions options)
    {
        var sb = new StringBuilder();

        if (Interchanges != null && Interchanges.Count > 0)
        {
            foreach (var interchange in Interchanges)
                AppendInterchange(sb, interchange, options);
            return sb.ToString();
        }

        // Legacy fallback: build a single interchange/group from the flat properties, matching the
        // behaviour this method had before Interchanges existed.
        if (InterchangeControlHeader == null)
            return sb.ToString();

        sb.Append(InterchangeControlHeader.ToString());
        if (GsHeader != null)
            sb.Append(Map.SegmentToString(GsHeader, options));

        foreach (var section in Sections)
            AppendSection(sb, section, options);

        if (GsHeader != null)
        {
            var groupEnd = new GenericFunctionalGroupTrailer();
            groupEnd.NumberOfTransactionSetsIncluded = Sections.Count;
            groupEnd.GroupControlNumber = int.Parse(GsHeader.GroupControlNumber);
            sb.Append(Map.SegmentToString(groupEnd, options));
        }

        var isaEnd = new GenericInterchangeControlTrailer();
        isaEnd.InterchangeControlNumber = InterchangeControlHeader.InterchangeControlNumber.ToString().PadLeft(9, '0');
        isaEnd.NumberOfIncludedFunctionalGroups = 1;
        sb.Append(Map.SegmentToString(isaEnd, options));

        return sb.ToString();
    }

    private static void AppendInterchange(StringBuilder sb, x12Interchange interchange, MapOptions options)
    {
        if (interchange?.Header == null)
            return;

        sb.Append(interchange.Header.ToString());

        foreach (var group in interchange.FunctionalGroups)
        {
            if (group.Header != null)
                sb.Append(Map.SegmentToString(group.Header, options));

            foreach (var section in group.Sections)
                AppendSection(sb, section, options);

            var groupEnd = new GenericFunctionalGroupTrailer();
            groupEnd.NumberOfTransactionSetsIncluded = group.Sections.Count;
            groupEnd.GroupControlNumber = group.Header != null
                ? int.Parse(group.Header.GroupControlNumber)
                : group.Trailer?.GroupControlNumber ?? 0;
            sb.Append(Map.SegmentToString(groupEnd, options));
        }

        var isaEnd = new GenericInterchangeControlTrailer();
        isaEnd.InterchangeControlNumber = interchange.Header.InterchangeControlNumber.ToString().PadLeft(9, '0');
        isaEnd.NumberOfIncludedFunctionalGroups = interchange.FunctionalGroups.Count;
        sb.Append(Map.SegmentToString(isaEnd, options));
    }

    private static void AppendSection(StringBuilder sb, Section section, MapOptions options)
    {
        var header = section.TransactionSetHeader ?? new ST_TransactionSetHeader
        {
            TransactionSetControlNumber = section.TransactionSetControlNumber,
            TransactionSetIdentifierCode = section.SectionType
        };
        var headerText = Map.SegmentToString(header, options);
        if (!string.IsNullOrEmpty(headerText))
            sb.Append(headerText);

        var lines = 0;
        foreach (var segment in section.Segments)
        {
            if (segment != null)
                sb.Append(Map.SegmentToString(segment, options));
            lines++;
        }

        var footer = new SE_TransactionSetTrailer();
        footer.NumberOfIncludedSegments = lines + 2; //ST + segments + SE
        footer.TransactionSetControlNumber = section.TransactionSetControlNumber;
        sb.Append(Map.SegmentToString(footer, options));
    }

    public static x12Document Parse(string data)
    {
        return Parse(data, new x12ParseOptions());
    }

    public static x12Document Parse(string data, x12ParseOptions parseOptions)
    {
        parseOptions = parseOptions ?? new x12ParseOptions();
        return new x12DocumentParser(parseOptions).Parse(data ?? string.Empty);
    }

    /// <summary>
    /// Recomputes every SE/GE/IEA control count and control number in <paramref name="text"/> and splices
    /// any that are wrong (or reports any trailer that is missing) without disturbing anything else in the
    /// text. <paramref name="text"/> is always parsed leniently internally so a document with wrong counts
    /// - which would otherwise fail structural validation - can still be walked and fixed; <paramref
    /// name="options"/> is accepted for forward compatibility but its Lenient flag is not consulted.
    /// Returns the original text unchanged (and an empty Changes list) when every trailer already agrees
    /// with what its container actually contains.
    /// </summary>
    public static ControlCountResult RecalculateControlCounts(string text, x12ParseOptions options = null)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text));

        var doc = Parse(text, new x12ParseOptions { Lenient = true });

        var changes = new List<ControlCountChange>();
        var splices = new List<PendingSplice>();

        foreach (var interchange in doc.Interchanges)
        {
            var mapOptions = interchange.MapOptions ?? (interchange.Header != null ? MapOptions.FromInterchangeHeader(interchange.Header) : null);

            foreach (var group in interchange.FunctionalGroups)
            {
                foreach (var section in group.Sections)
                    ReconcileSe(section, changes, splices, mapOptions);

                ReconcileGe(group, changes, splices, mapOptions);
            }

            ReconcileIea(interchange, changes, splices, mapOptions);
        }

        var resultText = text;
        foreach (var splice in splices.OrderByDescending(s => s.Source.StartOffset))
            resultText = SourceEdit.Replace(resultText, splice.Source, splice.NewText);

        return new ControlCountResult { Text = resultText, Changes = changes };
    }

    private static void ReconcileSe(Section section, List<ControlCountChange> changes, List<PendingSplice> splices, MapOptions mapOptions)
    {
        var expectedCount = section.Segments.Count + 2; // ST + segments + SE
        var expectedControl = section.TransactionSetControlNumber;
        var trailer = section.TransactionSetTrailer;

        if (trailer == null)
        {
            var lineNumber = section.TransactionSetHeader?.Source?.LineNumber ?? 0;
            changes.Add(new ControlCountChange { Trailer = "SE", LineNumber = lineNumber, Field = "NumberOfIncludedSegments", OldValue = null, NewValue = expectedCount.ToString() });
            changes.Add(new ControlCountChange { Trailer = "SE", LineNumber = lineNumber, Field = "TransactionSetControlNumber", OldValue = null, NewValue = expectedControl });
            return;
        }

        var changed = false;
        var lineNo = trailer.Source?.LineNumber ?? 0;

        if (trailer.NumberOfIncludedSegments != expectedCount)
        {
            changes.Add(new ControlCountChange { Trailer = "SE", LineNumber = lineNo, Field = "NumberOfIncludedSegments", OldValue = trailer.NumberOfIncludedSegments?.ToString(), NewValue = expectedCount.ToString() });
            trailer.NumberOfIncludedSegments = expectedCount;
            changed = true;
        }

        if (trailer.TransactionSetControlNumber != expectedControl)
        {
            changes.Add(new ControlCountChange { Trailer = "SE", LineNumber = lineNo, Field = "TransactionSetControlNumber", OldValue = trailer.TransactionSetControlNumber, NewValue = expectedControl });
            trailer.TransactionSetControlNumber = expectedControl;
            changed = true;
        }

        if (changed && trailer.Source != null && mapOptions != null)
            splices.Add(new PendingSplice { Source = trailer.Source, NewText = Map.SegmentToString(trailer, mapOptions, false) });
    }

    private static void ReconcileGe(x12FunctionalGroup group, List<ControlCountChange> changes, List<PendingSplice> splices, MapOptions mapOptions)
    {
        var expectedCount = group.Sections.Count;
        int? expectedControl = null;
        if (group.Header != null && int.TryParse(group.Header.GroupControlNumber, out var parsedControl))
            expectedControl = parsedControl;

        var trailer = group.Trailer;
        if (trailer == null)
        {
            var lineNumber = group.Header?.Source?.LineNumber ?? 0;
            changes.Add(new ControlCountChange { Trailer = "GE", LineNumber = lineNumber, Field = "NumberOfTransactionSetsIncluded", OldValue = null, NewValue = expectedCount.ToString() });
            changes.Add(new ControlCountChange { Trailer = "GE", LineNumber = lineNumber, Field = "GroupControlNumber", OldValue = null, NewValue = expectedControl?.ToString() });
            return;
        }

        var changed = false;
        var lineNo = trailer.Source?.LineNumber ?? 0;

        if (trailer.NumberOfTransactionSetsIncluded != expectedCount)
        {
            changes.Add(new ControlCountChange { Trailer = "GE", LineNumber = lineNo, Field = "NumberOfTransactionSetsIncluded", OldValue = trailer.NumberOfTransactionSetsIncluded?.ToString(), NewValue = expectedCount.ToString() });
            trailer.NumberOfTransactionSetsIncluded = expectedCount;
            changed = true;
        }

        if (expectedControl.HasValue && trailer.GroupControlNumber != expectedControl)
        {
            changes.Add(new ControlCountChange { Trailer = "GE", LineNumber = lineNo, Field = "GroupControlNumber", OldValue = trailer.GroupControlNumber?.ToString(), NewValue = expectedControl.ToString() });
            trailer.GroupControlNumber = expectedControl;
            changed = true;
        }

        if (changed && trailer.Source != null && mapOptions != null)
            splices.Add(new PendingSplice { Source = trailer.Source, NewText = Map.SegmentToString(trailer, mapOptions, false) });
    }

    private static void ReconcileIea(x12Interchange interchange, List<ControlCountChange> changes, List<PendingSplice> splices, MapOptions mapOptions)
    {
        var expectedCount = interchange.FunctionalGroups.Count;
        var expectedControl = interchange.Header?.InterchangeControlNumber?.ToString().PadLeft(9, '0');
        var trailer = interchange.Trailer;

        if (trailer == null)
        {
            var lineNumber = interchange.Header?.Source?.LineNumber ?? 0;
            changes.Add(new ControlCountChange { Trailer = "IEA", LineNumber = lineNumber, Field = "NumberOfIncludedFunctionalGroups", OldValue = null, NewValue = expectedCount.ToString() });
            changes.Add(new ControlCountChange { Trailer = "IEA", LineNumber = lineNumber, Field = "InterchangeControlNumber", OldValue = null, NewValue = expectedControl });
            return;
        }

        var changed = false;
        var lineNo = trailer.Source?.LineNumber ?? 0;

        if (trailer.NumberOfIncludedFunctionalGroups != expectedCount)
        {
            changes.Add(new ControlCountChange { Trailer = "IEA", LineNumber = lineNo, Field = "NumberOfIncludedFunctionalGroups", OldValue = trailer.NumberOfIncludedFunctionalGroups?.ToString(), NewValue = expectedCount.ToString() });
            trailer.NumberOfIncludedFunctionalGroups = expectedCount;
            changed = true;
        }

        if (expectedControl != null && trailer.InterchangeControlNumber != expectedControl)
        {
            changes.Add(new ControlCountChange { Trailer = "IEA", LineNumber = lineNo, Field = "InterchangeControlNumber", OldValue = trailer.InterchangeControlNumber, NewValue = expectedControl });
            trailer.InterchangeControlNumber = expectedControl;
            changed = true;
        }

        if (changed && trailer.Source != null && mapOptions != null)
            splices.Add(new PendingSplice { Source = trailer.Source, NewText = Map.SegmentToString(trailer, mapOptions, false) });
    }

    private struct PendingSplice
    {
        public SegmentSource Source;
        public string NewText;
    }
}

/// <summary>
/// Stateful worker behind x12Document.Parse. One instance is used per call.
/// </summary>
internal class x12DocumentParser
{
    private readonly x12ParseOptions _parseOptions;
    private readonly x12Document _doc = new();

    private string _data;
    private char _terminator;
    private char _dataSeparator;
    private MapOptions _mapOptions;

    private x12Interchange _currentInterchange;
    private x12FunctionalGroup _currentGroup;
    private Section _currentSection;

    private bool _firstInterchangeSeen;
    private bool _firstGroupSeen;
    private bool _expectGsNext;
    private bool _stopped;
    private int _lineNumber;

    public x12DocumentParser(x12ParseOptions parseOptions)
    {
        _parseOptions = parseOptions;
    }

    public x12Document Parse(string data)
    {
        _data = data;

        var pos = SkipWhitespace(0);

        if (pos + 4 > _data.Length || _data.Substring(pos, 3) != "ISA")
        {
            FailInvalidHeader(pos, $"Expected the document to start with an ISA segment but it did not");
            return _doc;
        }

        _dataSeparator = _data[pos + 3];

        if (pos + 106 > _data.Length)
        {
            FailInvalidHeader(pos, $"Expected file to be at least {pos + 106} characters long but was {_data.Length} characters");
            return _doc;
        }

        _terminator = _data[pos + 105];

        var segments = ScanSegments(pos);

        foreach (var seg in segments)
        {
            if (_stopped)
                break;

            _lineNumber++;
            var identifier = GetIdentifier(seg.Text);

            if (_expectGsNext)
            {
                _expectGsNext = false;
                if (identifier != "GS")
                    HandleMissingGs(seg);
                if (_stopped)
                    break;
            }

            switch (identifier)
            {
                case "ISA":
                    HandleIsa(seg);
                    break;
                case "GS":
                    HandleGs(seg);
                    break;
                case "GE":
                    HandleGe(seg);
                    break;
                case "IEA":
                    HandleIea(seg);
                    break;
                case "ST":
                    HandleSt(seg);
                    break;
                case "SE":
                    HandleSe(seg);
                    break;
                default:
                    HandleSegment(seg, identifier);
                    break;
            }
        }

        if (!_stopped)
            CloseInterchange(missingTrailer: true);

        return _doc;
    }

    // ---- segment handlers -------------------------------------------------

    private void HandleIsa(RawSegment seg)
    {
        CloseInterchange(missingTrailer: true);

        GenericInterchangeControlHeader header;
        if (_parseOptions.Lenient)
        {
            try
            {
                header = GenericInterchangeControlHeader.FromString(seg.Text + _terminator);
            }
            catch (InvalidFileFormatException ex)
            {
                var vr = NewResult(seg, "ISA");
                vr.Add(new Error(ErrorCodes.InvalidInterchangeHeader, ex.Message));
                _doc.ValidationErrors.Add(vr);
                _stopped = true;
                return;
            }
        }
        else
        {
            header = GenericInterchangeControlHeader.FromString(seg.Text + _terminator);
        }

        header.Source = SourceFor(seg);

        _currentInterchange = new x12Interchange { Header = header };
        _doc.Interchanges.Add(_currentInterchange);
        if (!_firstInterchangeSeen)
        {
            _doc.InterchangeControlHeader = header;
            _firstInterchangeSeen = true;
        }

        _mapOptions = MapOptions.FromInterchangeHeader(header);
        _currentInterchange.MapOptions = _mapOptions;
        if (_doc.MapOptions == null)
            _doc.MapOptions = _mapOptions;

        _currentGroup = null;
        _currentSection = null;
        _expectGsNext = true;
    }

    private void HandleMissingGs(RawSegment seg)
    {
        var vr = NewResult(seg, "GS");
        vr.Add(new Error(ErrorCodes.MissingFunctionalGroupHeader));

        if (!_parseOptions.Lenient)
        {
            _stopped = true;
            throw new InvalidFileFormatException(vr.Errors[0].ToString());
        }

        _doc.ValidationErrors.Add(vr);
        _currentGroup = new x12FunctionalGroup { Header = null };
        _currentInterchange.FunctionalGroups.Add(_currentGroup);
        _firstGroupSeen = true; // first group's header is null; GsHeader legacy stays null too
    }

    private void HandleGs(RawSegment seg)
    {
        if (_currentInterchange == null)
        {
            HandleSegment(seg, "GS");
            return;
        }

        CloseGroup(missingTrailer: true);

        var header = Map.MapObject<GenericFunctionalGroupHeader>(seg.Text, _mapOptions);
        header.Source = SourceFor(seg);

        _currentGroup = new x12FunctionalGroup { Header = header };
        _currentInterchange.FunctionalGroups.Add(_currentGroup);
        if (!_firstGroupSeen)
        {
            _doc.GsHeader = header;
            _firstGroupSeen = true;
        }

        _currentSection = null;
    }

    private void HandleGe(RawSegment seg)
    {
        if (_currentGroup == null)
        {
            RecordUnexpectedTrailer(seg, "GE");
            return;
        }

        CloseSection(missingTrailer: true);

        var ge = Map.MapObject<GenericFunctionalGroupTrailer>(seg.Text, _mapOptions);
        ge.Source = SourceFor(seg);
        _currentGroup.Trailer = ge;

        var vr = NewResult(seg, "GE");
        if (ge.NumberOfTransactionSetsIncluded != _currentGroup.Sections.Count)
            vr.Add(new Error(ErrorCodes.FunctionalGroupSectionCountMismatch, ge.NumberOfTransactionSetsIncluded.ToString(), _currentGroup.Sections.Count.ToString()));
        if (_currentGroup.Header != null && ge.GroupControlNumber != int.Parse(_currentGroup.Header.GroupControlNumber))
            vr.Add(new Error(ErrorCodes.FunctionalGroupControlNumberMismatch, _currentGroup.Header.GroupControlNumber, ge.GroupControlNumber.ToString()));
        if (vr.Errors.Count > 0)
            _doc.ValidationErrors.Add(vr);

        _currentGroup = null;
    }

    private void HandleIea(RawSegment seg)
    {
        if (_currentInterchange == null)
        {
            RecordUnexpectedTrailer(seg, "IEA");
            return;
        }

        CloseGroup(missingTrailer: true);

        var iea = Map.MapObject<GenericInterchangeControlTrailer>(seg.Text, _mapOptions);
        iea.Source = SourceFor(seg);
        _currentInterchange.Trailer = iea;

        var vr = NewResult(seg, "IEA");
        if (iea.NumberOfIncludedFunctionalGroups != _currentInterchange.FunctionalGroups.Count)
            vr.Add(new Error(ErrorCodes.InterchangeGroupCountMismatch, iea.NumberOfIncludedFunctionalGroups.ToString(), _currentInterchange.FunctionalGroups.Count.ToString()));

        var expectedControl = _currentInterchange.Header.InterchangeControlNumber.ToString().PadLeft(9, '0');
        if (iea.InterchangeControlNumber != expectedControl)
            vr.Add(new Error(ErrorCodes.InterchangeControlNumberMismatch, expectedControl, iea.InterchangeControlNumber));
        if (vr.Errors.Count > 0)
            _doc.ValidationErrors.Add(vr);

        _currentInterchange = null;
    }

    private void HandleSt(RawSegment seg)
    {
        if (_currentInterchange == null)
        {
            HandleSegment(seg, "ST");
            return;
        }

        if (_currentGroup == null)
        {
            _currentGroup = new x12FunctionalGroup { Header = null };
            _currentInterchange.FunctionalGroups.Add(_currentGroup);
        }

        CloseSection(missingTrailer: true);

        var st = Map.MapObject<ST_TransactionSetHeader>(seg.Text, _mapOptions);
        st.Source = SourceFor(seg);

        _currentSection = new Section
        {
            SectionType = st.TransactionSetIdentifierCode,
            TransactionSetControlNumber = st.TransactionSetControlNumber,
            TransactionSetHeader = st
        };
        _currentGroup.Sections.Add(_currentSection);
        _doc.Sections.Add(_currentSection);
    }

    private void HandleSe(RawSegment seg)
    {
        if (_currentSection == null)
        {
            RecordUnexpectedTrailer(seg, "SE");
            return;
        }

        var se = Map.MapObject<SE_TransactionSetTrailer>(seg.Text, _mapOptions);
        se.Source = SourceFor(seg);
        _currentSection.TransactionSetTrailer = se;

        var vr = NewResult(seg, "SE");
        if (se.NumberOfIncludedSegments != _currentSection.Segments.Count + 2)
            vr.Add(new Error(ErrorCodes.TransactionSetSegmentCountMismatch, se.NumberOfIncludedSegments.ToString(), (_currentSection.Segments.Count + 2).ToString()));
        if (se.TransactionSetControlNumber != _currentSection.TransactionSetControlNumber)
            vr.Add(new Error(ErrorCodes.TransactionSetControlNumberMismatch, _currentSection.TransactionSetControlNumber, se.TransactionSetControlNumber));
        if (vr.Errors.Count > 0)
            _doc.ValidationErrors.Add(vr);

        _currentSection = null;
    }

    private void HandleSegment(RawSegment seg, string identifier)
    {
        if (_currentSection != null)
        {
            var segment = TryBuildSegment(seg, identifier, out var parseFailed);
            if (parseFailed)
            {
                var failVr = NewResult(seg, identifier);
                failVr.Add(new Error(ErrorCodes.SegmentParseFailure, identifier, "the segment could not be mapped"));
                _doc.ValidationErrors.Add(failVr);
                return;
            }

            _currentSection.Segments.Add(segment);
            var validationResult = segment.Validate();
            if (!validationResult.IsValid)
            {
                validationResult.LineNumber = _lineNumber;
                validationResult.SegmentCode = identifier;
                validationResult.Source = segment.Source;
                _doc.ValidationErrors.Add(validationResult);
            }
            return;
        }

        // Outside of any ST/SE transaction set: nearest open container gets it as an orphan.
        var orphan = TryBuildSegment(seg, identifier, out var failed);
        if (!failed && orphan != null)
        {
            if (_currentGroup != null)
                _currentGroup.OrphanSegments.Add(orphan);
            else
                _currentInterchange?.OrphanSegments.Add(orphan);
        }

        var vr = NewResult(seg, identifier);
        vr.Add(new Error(ErrorCodes.SegmentOutsideTransactionSet, identifier));
        if (_parseOptions.Lenient)
        {
            _doc.ValidationErrors.Add(vr);
        }
        else
        {
            throw new InvalidFileFormatException(vr.Errors[0].ToString());
        }
    }

    // ---- segment construction ---------------------------------------------

    private EdiX12Segment TryBuildSegment(RawSegment seg, string identifier, out bool failed)
    {
        failed = false;

        if (!EdiSectionParserFactory.TryGetSegmentFor(_mapOptions.StandardsVersion, identifier, out var segType))
        {
            if (!_parseOptions.Lenient)
                throw new InvalidFileFormatException($"Segment '{identifier}' is not defined in version {_mapOptions.StandardsVersion} (line {_lineNumber})");

            var unknown = new Unknown_Segment
            {
                SegmentId = identifier,
                Elements = SplitElements(seg.Text),
                Version = _mapOptions.StandardsVersion,
                Source = SourceFor(seg)
            };
            return unknown;
        }

        try
        {
            var segment = Map.MapObject(segType, seg.Text, _mapOptions);
            segment.Source = SourceFor(seg);
            return segment;
        }
        catch (Exception ex) when (!(ex is InvalidFileFormatException))
        {
            if (!_parseOptions.Lenient)
                throw new InvalidFileFormatException($"Segment '{identifier}' could not be parsed: {ex.Message} (line {_lineNumber})");

            failed = true;
            return null;
        }
    }

    private List<string> SplitElements(string text)
    {
        var parts = text.Split(_mapOptions.Separator.ToCharArray());
        return parts.Skip(1).Select(p => p.Trim()).ToList();
    }

    // ---- closing / trailer bookkeeping ------------------------------------

    // Note: a missing trailer is only ever reported in lenient mode. Strict/default parsing never checked
    // for a trailer's *absence* even before Interchanges existed (an IEA-less file was, and still is, a
    // perfectly valid parse as far as x12Document.Parse(data) is concerned) -- we only make it stricter
    // about content that IS present (unknown segments, a missing GS immediately after ISA, etc). That is
    // the boundary the task draws between "strict keeps throwing for malformed input" and "lenient never
    // throws for content problems": whether a trailer showed up at all is a content problem, so it lives
    // in the lenient-only bucket together with the rest of that list.

    private void CloseSection(bool missingTrailer)
    {
        if (_currentSection == null)
            return;

        if (missingTrailer && _parseOptions.Lenient && _currentSection.TransactionSetTrailer == null)
            RecordMissingTrailer("SE", _currentSection.TransactionSetControlNumber);

        _currentSection = null;
    }

    private void CloseGroup(bool missingTrailer)
    {
        CloseSection(missingTrailer);

        if (_currentGroup == null)
            return;

        if (missingTrailer && _parseOptions.Lenient && _currentGroup.Trailer == null)
            RecordMissingTrailer("GE", _currentGroup.Header?.GroupControlNumber);

        _currentGroup = null;
    }

    private void CloseInterchange(bool missingTrailer)
    {
        CloseGroup(missingTrailer);

        if (_currentInterchange == null)
            return;

        if (missingTrailer && _parseOptions.Lenient && _currentInterchange.Trailer == null)
            RecordMissingTrailer("IEA", _currentInterchange.Header?.InterchangeControlNumber?.ToString());

        _currentInterchange = null;
    }

    /// <summary>Only ever called when parsing leniently -- see the note above CloseSection.</summary>
    private void RecordMissingTrailer(string trailerCode, string forWhat)
    {
        var vr = new ValidationResult { LineNumber = _lineNumber, SegmentCode = trailerCode };
        vr.Add(new Error(ErrorCodes.MissingTrailer, trailerCode, forWhat ?? ""));
        _doc.ValidationErrors.Add(vr);
    }

    private void RecordUnexpectedTrailer(RawSegment seg, string code)
    {
        var vr = NewResult(seg, code);
        vr.Add(new Error(ErrorCodes.UnexpectedTrailer, code));

        if (_parseOptions.Lenient)
        {
            _doc.ValidationErrors.Add(vr);
        }
        else
        {
            throw new InvalidFileFormatException(vr.Errors[0].ToString());
        }
    }

    private void FailInvalidHeader(int pos, string message)
    {
        var vr = new ValidationResult { LineNumber = 1, SegmentCode = "ISA" };
        vr.Add(new Error(ErrorCodes.InvalidInterchangeHeader, message));

        if (!_parseOptions.Lenient)
            throw new InvalidFileFormatException(vr.Errors[0].ToString());

        _doc.ValidationErrors.Add(vr);
        _stopped = true;
    }

    // ---- low level scanning -------------------------------------------------

    private ValidationResult NewResult(RawSegment seg, string segmentCode)
    {
        return new ValidationResult { LineNumber = _lineNumber, SegmentCode = segmentCode, Source = SourceFor(seg) };
    }

    private SegmentSource SourceFor(RawSegment seg)
    {
        return new SegmentSource(_lineNumber, seg.Start, seg.Length, seg.Text);
    }

    private string GetIdentifier(string text)
    {
        if (text.Length >= 3 && text[0] == 'I' && text[1] == 'S' && text[2] == 'A')
            return "ISA";

        var idx = text.IndexOf(_dataSeparator);
        return idx >= 0 ? text.Substring(0, idx) : text;
    }

    private int SkipWhitespace(int from)
    {
        var i = from;
        while (i < _data.Length && IsWhitespace(_data[i]))
            i++;
        return i;
    }

    private static bool IsWhitespace(char c)
    {
        return c == ' ' || c == '\r' || c == '\n' || c == '\t' || c == '\uFEFF';
    }

    private List<RawSegment> ScanSegments(int fromIndex)
    {
        var result = new List<RawSegment>();
        var cursor = fromIndex;

        while (cursor <= _data.Length)
        {
            var idx = _data.IndexOf(_terminator, cursor);
            string chunk;
            var chunkStart = cursor;
            bool atEnd;

            if (idx < 0)
            {
                chunk = _data.Substring(cursor);
                atEnd = true;
            }
            else
            {
                chunk = _data.Substring(cursor, idx - cursor);
                atEnd = false;
            }

            var len = chunk.Length;
            var s = 0;
            while (s < len && IsWhitespace(chunk[s]))
                s++;
            var e = len;
            while (e > s && IsWhitespace(chunk[e - 1]))
                e--;

            if (e > s)
                result.Add(new RawSegment(chunk.Substring(s, e - s), chunkStart + s, e - s));

            if (atEnd)
                break;
            cursor = idx + 1;
        }

        return result;
    }

    private readonly struct RawSegment
    {
        public RawSegment(string text, int start, int length)
        {
            Text = text;
            Start = start;
            Length = length;
        }

        public string Text { get; }
        public int Start { get; }
        public int Length { get; }
    }
}
