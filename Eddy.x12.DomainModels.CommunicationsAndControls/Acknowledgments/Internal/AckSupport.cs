using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Eddy.Core.Validation;
using Eddy.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments.Internal
{
    internal enum AckVersionBucket
    {
        V4010,
        V5010
    }

    /// <summary>
    /// IK4's PositionInSegment (C030) was introduced fresh in the v5010 model set, several versioned subclasses
    /// below EdiX12Component (v5010 -&gt; v4060 -&gt; ... -&gt; v4020 -&gt; EdiX12Component). Map.ItemToString only recognizes a
    /// property as a composite when its declared type's *immediate* base class is EdiX12Component, so a property
    /// declared with this deeper type falls through to Map's plain-value fallback, which calls the property's
    /// value.ToString(). Overriding ToString() here (rather than editing the shared mapper) makes that fallback
    /// render the one sub-element we ever populate (element position in segment) correctly; AK4's own PositionInSegment
    /// is a shallower type (declared directly under EdiX12Component) and needs no such workaround.
    /// </summary>
    internal sealed class Ik4PositionInSegment : Eddy.x12.Models.v5010.Composites.C030_PositionInSegment
    {
        public override string ToString()
        {
            return ElementPositionInSegment?.ToString() ?? string.Empty;
        }
    }

    /// <summary>One data-element-level problem found on a single segment (becomes one AK4/IK4).</summary>
    internal class ElementErrorInfo
    {
        public int? ElementPosition;
        public string ErrorCode;
        public string BadValue;
    }

    /// <summary>One segment-level problem (becomes one AK3/IK3, with an AK4/IK4 per element problem it carries).</summary>
    internal class SegmentErrorInfo
    {
        public string SegmentIdCode;
        public int SegmentPosition;
        public string SegmentErrorCode;
        public List<ElementErrorInfo> Elements = new List<ElementErrorInfo>();
    }

    /// <summary>Everything needed to acknowledge one input transaction set (becomes one AK2 loop).</summary>
    internal class TransactionAckInfo
    {
        public string TransactionSetIdentifierCode;
        public string TransactionSetControlNumber;
        public List<SegmentErrorInfo> SegmentErrors = new List<SegmentErrorInfo>();
        public bool SegmentCountMismatch;
        public bool ControlNumberMismatch;

        public string AckCode(AcknowledgmentOptions options)
        {
            var hasIdentityIssue = SegmentErrors.Any(s => s.SegmentErrorCode != "8");
            var hasElementIssue = SegmentErrors.Any(s => s.SegmentErrorCode == "8");

            if (hasIdentityIssue || SegmentCountMismatch || ControlNumberMismatch)
                return "R";
            if (hasElementIssue)
                return options.AcceptWithErrors ? "E" : "R";
            return "A";
        }

        public List<string> SyntaxCodes()
        {
            var codes = new List<string>();
            if (SegmentErrors.Count > 0)
                codes.Add("5");
            if (SegmentCountMismatch)
                codes.Add("4");
            if (ControlNumberMismatch)
                codes.Add("3");
            return codes;
        }
    }

    /// <summary>Everything needed to acknowledge one input functional group (becomes one AK1 + AK9 pair).</summary>
    internal class GroupAckInfo
    {
        public GenericFunctionalGroupHeader InputHeader;
        public List<TransactionAckInfo> Transactions = new List<TransactionAckInfo>();
        public bool SectionCountMismatch;
        public bool ControlNumberMismatch;

        public List<string> SyntaxCodes()
        {
            var codes = new List<string>();
            if (SectionCountMismatch)
                codes.Add("4");
            if (ControlNumberMismatch)
                codes.Add("3");
            return codes;
        }

        public string FunctionalGroupAckCode(AcknowledgmentOptions options)
        {
            var total = Transactions.Count;
            if (total == 0)
                return "R";

            var accepted = Transactions.Count(t => t.AckCode(options) != "R");
            if (accepted == 0)
                return "R";
            if (accepted < total)
                return "P";
            return Transactions.All(t => t.AckCode(options) == "A") ? "A" : "E";
        }
    }

    internal static class AckSupport
    {
        public static AckVersionBucket DetermineBucket(string gs08)
        {
            var version = gs08 ?? string.Empty;
            if (version.StartsWith("003", StringComparison.Ordinal) || version.StartsWith("004", StringComparison.Ordinal))
                return AckVersionBucket.V4010;
            return AckVersionBucket.V5010;
        }

        /// <summary>
        /// Walks every interchange/functional group/section of the input document, matching each ValidationResult
        /// to the transaction set (and, where relevant, the segment/element within it) that it belongs to.
        /// Structural problems that don't belong to any transaction set (a missing GS, an IEA/ISA-level mismatch, a
        /// segment that appeared outside of any ST/SE) are not reflected in the result -- there is nowhere in a
        /// 997/999 to report them, and callers should never see Build997/Build999 throw over them.
        /// </summary>
        public static List<GroupAckInfo> BuildGroupAckInfos(x12Document input)
        {
            var result = new List<GroupAckInfo>();
            if (input?.Interchanges == null)
                return result;

            foreach (var interchange in input.Interchanges)
            {
                if (interchange?.FunctionalGroups == null)
                    continue;

                foreach (var group in interchange.FunctionalGroups)
                {
                    var groupInfo = new GroupAckInfo { InputHeader = group.Header };

                    // segment.Source.LineNumber -> which section/position it belongs to (position counted from ST = 1).
                    var segmentPositionByLine = new Dictionary<int, Tuple<Section, int>>();
                    // SE's own Source.LineNumber -> the section it trails, for TransactionSetSegmentCountMismatch/
                    // TransactionSetControlNumberMismatch (those errors carry the SE's source, not a body segment's).
                    var sectionByTrailerLine = new Dictionary<int, Section>();
                    var transactionInfoBySection = new Dictionary<Section, TransactionAckInfo>();

                    foreach (var section in group.Sections ?? new List<Section>())
                    {
                        var info = new TransactionAckInfo
                        {
                            TransactionSetIdentifierCode = section.SectionType,
                            TransactionSetControlNumber = section.TransactionSetControlNumber
                        };
                        groupInfo.Transactions.Add(info);
                        transactionInfoBySection[section] = info;

                        var segments = section.Segments ?? new List<EdiX12Segment>();
                        for (var i = 0; i < segments.Count; i++)
                        {
                            var segment = segments[i];
                            if (segment?.Source != null)
                                segmentPositionByLine[segment.Source.LineNumber] = Tuple.Create(section, i + 2); // ST is position 1

                        }

                        if (section.TransactionSetTrailer?.Source != null)
                            sectionByTrailerLine[section.TransactionSetTrailer.Source.LineNumber] = section;
                    }

                    var geLine = group.Trailer?.Source?.LineNumber;

                    foreach (var vr in input.ValidationErrors ?? new List<ValidationResult>())
                    {
                        if (vr?.Source == null)
                            continue;

                        var line = vr.Source.LineNumber;

                        if (geLine.HasValue && line == geLine.Value)
                        {
                            foreach (var error in vr.Errors)
                            {
                                if (error.ErrorCode == ErrorCodes.FunctionalGroupSectionCountMismatch)
                                    groupInfo.SectionCountMismatch = true;
                                else if (error.ErrorCode == ErrorCodes.FunctionalGroupControlNumberMismatch)
                                    groupInfo.ControlNumberMismatch = true;
                            }
                            continue;
                        }

                        if (sectionByTrailerLine.TryGetValue(line, out var trailerSection))
                        {
                            var info = transactionInfoBySection[trailerSection];
                            foreach (var error in vr.Errors)
                            {
                                if (error.ErrorCode == ErrorCodes.TransactionSetSegmentCountMismatch)
                                    info.SegmentCountMismatch = true;
                                else if (error.ErrorCode == ErrorCodes.TransactionSetControlNumberMismatch)
                                    info.ControlNumberMismatch = true;
                            }
                            continue;
                        }

                        if (segmentPositionByLine.TryGetValue(line, out var positionInfo))
                        {
                            var section = positionInfo.Item1;
                            var position = positionInfo.Item2;
                            var segment = section.Segments[position - 2];
                            var info = transactionInfoBySection[section];
                            info.SegmentErrors.Add(BuildSegmentErrorInfo(vr, position, segment));
                            continue;
                        }

                        // Anything else (missing GS, IEA/ISA-level mismatches, a segment appearing outside of any
                        // ST/SE) does not belong to a transaction set the 997/999 can report against -- ignored.
                    }

                    result.Add(groupInfo);
                }
            }

            return result;
        }

        private static SegmentErrorInfo BuildSegmentErrorInfo(ValidationResult vr, int position, EdiX12Segment segment)
        {
            var info = new SegmentErrorInfo
            {
                SegmentIdCode = vr.SegmentCode,
                SegmentPosition = position
            };

            var identityError = vr.Errors.FirstOrDefault(e =>
                e.ErrorCode == ErrorCodes.UnknownSegment || e.ErrorCode == ErrorCodes.SegmentOutsideTransactionSet);

            if (identityError != null)
            {
                info.SegmentErrorCode = identityError.ErrorCode == ErrorCodes.UnknownSegment ? "1" : "2";
                return info;
            }

            info.SegmentErrorCode = "8";
            foreach (var error in vr.Errors)
            {
                info.Elements.Add(new ElementErrorInfo
                {
                    ElementPosition = error.ElementPosition,
                    ErrorCode = ElementErrorCode(error),
                    BadValue = TryGetBadValue(segment, error.PropertyName)
                });
            }

            return info;
        }

        private static string ElementErrorCode(Error error)
        {
            if (error.ErrorCode == ErrorCodes.Required)
                return "1";

            if (error.ErrorCode == ErrorCodes.OutOfRange)
            {
                // Data: [propertyName, min, max, actualLength]
                if (error.Data != null && error.Data.Length >= 4
                    && int.TryParse(Convert.ToString(error.Data[1], CultureInfo.InvariantCulture), out var min)
                    && int.TryParse(Convert.ToString(error.Data[3], CultureInfo.InvariantCulture), out var actual))
                {
                    return actual < min ? "4" : "5";
                }
                return "7";
            }

            if (error.ErrorCode == ErrorCodes.ConvertibleToInteger)
                return "6";
            if (error.ErrorCode == ErrorCodes.DateIsNotValidFormat)
                return "8";
            if (error.ErrorCode == ErrorCodes.TimeIsNotValidFormat)
                return "9";

            return "7"; // invalid code value -- the catch-all for anything not called out above (e.g. ExactLength)
        }

        /// <summary>Best-effort lookup of the offending value straight off the segment, for AK4/IK404.</summary>
        public static string TryGetBadValue(EdiX12Segment segment, string propertyName)
        {
            if (segment == null || string.IsNullOrEmpty(propertyName))
                return null;

            var prop = segment.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null)
                return null;

            var value = prop.GetValue(segment, null);
            if (value == null)
                return null;

            var text = value.ToString();
            return text.Length > 99 ? text.Substring(0, 99) : text;
        }

        public static MapOptions DeriveMapOptions(GenericInterchangeControlHeader header)
        {
            return new MapOptions
            {
                Separator = header.DataElementSeparator.ToString(),
                ComponentElementSeparator = header.ComponentDataElementSeparator,
                LineEnding = header.ElementSeparator.ToString(),
                StandardsVersion = header.InterchangeControlVersionNumberCode + "0"
            };
        }

        public static GenericInterchangeControlHeader BuildOutputInterchangeHeader(GenericInterchangeControlHeader input, AcknowledgmentOptions options, int interchangeControlNumber)
        {
            var now = options.Clock();
            return new GenericInterchangeControlHeader
            {
                AuthorizationInformationQualifier = input.AuthorizationInformationQualifier,
                AuthorizationInformation = input.AuthorizationInformation,
                SecurityInformationQualifier = input.SecurityInformationQualifier,
                SecurityInformation = input.SecurityInformation,
                InterchangeSenderIDQualifier = options.SenderQualifier ?? input.InterchangeReceiverIDQualifier,
                InterchangeSenderID = options.SenderId ?? input.InterchangeReceiverID,
                InterchangeReceiverIDQualifier = options.ReceiverQualifier ?? input.InterchangeSenderIDQualifier,
                InterchangeReceiverID = options.ReceiverId ?? input.InterchangeSenderID,
                InterchangeDate = now.ToString("yyMMdd", CultureInfo.InvariantCulture),
                InterchangeTime = now.ToString("HHmm", CultureInfo.InvariantCulture),
                RepetitionSeparator = input.RepetitionSeparator,
                InterchangeControlVersionNumberCode = input.InterchangeControlVersionNumberCode,
                InterchangeControlNumber = interchangeControlNumber,
                AcknowledgmentRequestedCode = "0",
                InterchangeUsageIndicatorCode = options.UsageIndicator ?? input.InterchangeUsageIndicatorCode,
                ComponentDataElementSeparator = input.ComponentDataElementSeparator,
                DataElementSeparator = input.DataElementSeparator,
                ElementSeparator = input.ElementSeparator
            };
        }

        public static GenericFunctionalGroupHeader BuildOutputGroupHeader(GenericFunctionalGroupHeader inputGroupHeader, GenericInterchangeControlHeader outputIsa, AcknowledgmentOptions options, int groupControlNumber)
        {
            var now = options.Clock();
            return new GenericFunctionalGroupHeader
            {
                FunctionalIdentifierCode = "FA",
                ApplicationSendersCode = (outputIsa.InterchangeSenderID ?? string.Empty).Trim(),
                ApplicationReceiversCode = (outputIsa.InterchangeReceiverID ?? string.Empty).Trim(),
                Date = now.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
                Time = now.ToString("HHmm", CultureInfo.InvariantCulture),
                GroupControlNumber = groupControlNumber.ToString(CultureInfo.InvariantCulture),
                ResponsibleAgencyCode = "X",
                VersionReleaseIndustryIdentifierCode = inputGroupHeader?.VersionReleaseIndustryIdentifierCode
            };
        }

        public static int ParseControlNumberSeed(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 1;
            return int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : 1;
        }

        public static string FormatControlNumber(int value, int width)
        {
            var text = value.ToString(CultureInfo.InvariantCulture);
            return width > text.Length ? text.PadLeft(width, '0') : text;
        }
    }
}
