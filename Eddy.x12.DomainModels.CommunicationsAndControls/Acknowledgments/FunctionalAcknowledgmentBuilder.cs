using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Eddy.x12;
using Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments.Internal;
using Eddy.x12.Models;

using AK4Composite = Eddy.x12.Models.v3050.Composites.C030_PositionInSegment;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments
{
    /// <summary>
    /// Builds a 997 Functional Acknowledgment for an x12Document that was parsed (typically leniently) so its
    /// ValidationErrors can be turned into AK3/AK4/AK5/AK9 detail. One 997 (ST/AK1/[AK2 ...]/AK9/SE) is produced per
    /// functional group found in the input, each inside its own GS...GE, all inside a single ISA...IEA interchange
    /// mirrored back to the sender.
    /// </summary>
    public class FunctionalAcknowledgmentBuilder
    {
        public x12Document Build997(x12Document input, AcknowledgmentOptions options = null)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            options = options ?? new AcknowledgmentOptions();

            var inputHeader = input.Interchanges?.FirstOrDefault()?.Header ?? input.InterchangeControlHeader;
            if (inputHeader == null)
                throw new ArgumentException("The input document has no ISA header to acknowledge.", nameof(input));

            var groupInfos = AckSupport.BuildGroupAckInfos(input);

            var interchangeControlNumber = options.InterchangeControlNumber ?? inputHeader.InterchangeControlNumber ?? 1;
            var outputIsa = AckSupport.BuildOutputInterchangeHeader(inputHeader, options, interchangeControlNumber);

            var output = new x12Document();
            var interchange = new x12Interchange { Header = outputIsa };
            output.Interchanges.Add(interchange);

            var tsControlWidth = (options.TransactionSetControlNumber ?? "0001").Length;
            var tsControlSeed = AckSupport.ParseControlNumberSeed(options.TransactionSetControlNumber);

            for (var i = 0; i < groupInfos.Count; i++)
            {
                var groupInfo = groupInfos[i];

                var groupControlNumber = options.GroupControlNumber.HasValue
                    ? options.GroupControlNumber.Value + i
                    : AckSupport.ParseControlNumberSeed(groupInfo.InputHeader?.GroupControlNumber);

                var outputGroupHeader = AckSupport.BuildOutputGroupHeader(groupInfo.InputHeader, outputIsa, options, groupControlNumber);
                var functionalGroup = new x12FunctionalGroup { Header = outputGroupHeader };
                interchange.FunctionalGroups.Add(functionalGroup);

                var tsControlNumber = AckSupport.FormatControlNumber(tsControlSeed + i, tsControlWidth);
                var bucket = AckSupport.DetermineBucket(groupInfo.InputHeader?.VersionReleaseIndustryIdentifierCode);

                var body = bucket == AckVersionBucket.V5010
                    ? BuildBodyV5010(groupInfo, options)
                    : BuildBodyV4010(groupInfo, options);

                var section = new Section
                {
                    SectionType = "997",
                    TransactionSetControlNumber = tsControlNumber,
                    Segments = body
                };
                functionalGroup.Sections.Add(section);
            }

            return output;
        }

        public string Build997Text(x12Document input, AcknowledgmentOptions options = null)
        {
            var document = Build997(input, options);

            var inputHeader = input?.Interchanges?.FirstOrDefault()?.Header ?? input?.InterchangeControlHeader;
            if (inputHeader == null)
                throw new ArgumentException("The input document has no ISA header to derive separators from.", nameof(input));

            var mapOptions = AckSupport.DeriveMapOptions(inputHeader);
            return document.ToString(mapOptions);
        }

        private static List<EdiX12Segment> BuildBodyV4010(GroupAckInfo groupInfo, AcknowledgmentOptions options)
        {
            var body = new List<EdiX12Segment>();

            body.Add(new Eddy.x12.Models.v4010.AK1_FunctionalGroupResponseHeader
            {
                FunctionalIdentifierCode = groupInfo.InputHeader?.FunctionalIdentifierCode,
                GroupControlNumber = ParseIntOrNull(groupInfo.InputHeader?.GroupControlNumber)
            });

            foreach (var transaction in groupInfo.Transactions)
            {
                body.Add(new Eddy.x12.Models.v4010.AK2_TransactionSetResponseHeader
                {
                    TransactionSetIdentifierCode = transaction.TransactionSetIdentifierCode,
                    TransactionSetControlNumber = transaction.TransactionSetControlNumber
                });

                if (options.IncludeAK3AK4)
                {
                    foreach (var segmentError in transaction.SegmentErrors)
                    {
                        body.Add(new Eddy.x12.Models.v4010.AK3_DataSegmentNote
                        {
                            SegmentIDCode = segmentError.SegmentIdCode,
                            SegmentPositionInTransactionSet = segmentError.SegmentPosition,
                            SegmentSyntaxErrorCode = segmentError.SegmentErrorCode
                        });

                        foreach (var element in segmentError.Elements)
                        {
                            body.Add(new Eddy.x12.Models.v4010.AK4_DataElementNote
                            {
                                PositionInSegment = new AK4Composite { ElementPositionInSegment = element.ElementPosition },
                                DataElementSyntaxErrorCode = element.ErrorCode,
                                CopyOfBadDataElement = element.BadValue
                            });
                        }
                    }
                }

                body.Add(BuildAk5V4010(transaction, options));
            }

            body.Add(BuildAk9V4010(groupInfo, options));
            return body;
        }

        private static List<EdiX12Segment> BuildBodyV5010(GroupAckInfo groupInfo, AcknowledgmentOptions options)
        {
            var body = new List<EdiX12Segment>();

            body.Add(new Eddy.x12.Models.v5010.AK1_FunctionalGroupResponseHeader
            {
                FunctionalIdentifierCode = groupInfo.InputHeader?.FunctionalIdentifierCode,
                GroupControlNumber = ParseIntOrNull(groupInfo.InputHeader?.GroupControlNumber)
            });

            foreach (var transaction in groupInfo.Transactions)
            {
                body.Add(new Eddy.x12.Models.v5010.AK2_TransactionSetResponseHeader
                {
                    TransactionSetIdentifierCode = transaction.TransactionSetIdentifierCode,
                    TransactionSetControlNumber = transaction.TransactionSetControlNumber
                    // ImplementationConventionReference (AK203) intentionally left blank -- we don't know the
                    // implementation guide the input transaction set claims to follow.
                });

                if (options.IncludeAK3AK4)
                {
                    foreach (var segmentError in transaction.SegmentErrors)
                    {
                        body.Add(new Eddy.x12.Models.v5010.AK3_DataSegmentNote
                        {
                            SegmentIDCode = segmentError.SegmentIdCode,
                            SegmentPositionInTransactionSet = segmentError.SegmentPosition,
                            SegmentSyntaxErrorCode = segmentError.SegmentErrorCode
                        });

                        foreach (var element in segmentError.Elements)
                        {
                            body.Add(new Eddy.x12.Models.v5010.AK4_DataElementNote
                            {
                                PositionInSegment = new AK4Composite { ElementPositionInSegment = element.ElementPosition },
                                DataElementSyntaxErrorCode = element.ErrorCode,
                                CopyOfBadDataElement = element.BadValue
                            });
                        }
                    }
                }

                body.Add(BuildAk5V5010(transaction, options));
            }

            body.Add(BuildAk9V5010(groupInfo, options));
            return body;
        }

        private static Eddy.x12.Models.v4010.AK5_TransactionSetResponseTrailer BuildAk5V4010(TransactionAckInfo transaction, AcknowledgmentOptions options)
        {
            var codes = transaction.SyntaxCodes();
            return new Eddy.x12.Models.v4010.AK5_TransactionSetResponseTrailer
            {
                TransactionSetAcknowledgmentCode = transaction.AckCode(options),
                TransactionSetSyntaxErrorCode = codes.ElementAtOrDefault(0),
                TransactionSetSyntaxErrorCode2 = codes.ElementAtOrDefault(1),
                TransactionSetSyntaxErrorCode3 = codes.ElementAtOrDefault(2),
                TransactionSetSyntaxErrorCode4 = codes.ElementAtOrDefault(3),
                TransactionSetSyntaxErrorCode5 = codes.ElementAtOrDefault(4)
            };
        }

        private static Eddy.x12.Models.v5010.AK5_TransactionSetResponseTrailer BuildAk5V5010(TransactionAckInfo transaction, AcknowledgmentOptions options)
        {
            var codes = transaction.SyntaxCodes();
            return new Eddy.x12.Models.v5010.AK5_TransactionSetResponseTrailer
            {
                TransactionSetAcknowledgmentCode = transaction.AckCode(options),
                TransactionSetSyntaxErrorCode = codes.ElementAtOrDefault(0),
                TransactionSetSyntaxErrorCode2 = codes.ElementAtOrDefault(1),
                TransactionSetSyntaxErrorCode3 = codes.ElementAtOrDefault(2),
                TransactionSetSyntaxErrorCode4 = codes.ElementAtOrDefault(3),
                TransactionSetSyntaxErrorCode5 = codes.ElementAtOrDefault(4)
            };
        }

        private static Eddy.x12.Models.v4010.AK9_FunctionalGroupResponseTrailer BuildAk9V4010(GroupAckInfo groupInfo, AcknowledgmentOptions options)
        {
            var codes = groupInfo.SyntaxCodes();
            return new Eddy.x12.Models.v4010.AK9_FunctionalGroupResponseTrailer
            {
                FunctionalGroupAcknowledgeCode = groupInfo.FunctionalGroupAckCode(options),
                NumberOfTransactionSetsIncluded = groupInfo.Transactions.Count,
                NumberOfReceivedTransactionSets = groupInfo.Transactions.Count,
                NumberOfAcceptedTransactionSets = groupInfo.Transactions.Count(t => t.AckCode(options) != "R"),
                FunctionalGroupSyntaxErrorCode = codes.ElementAtOrDefault(0),
                FunctionalGroupSyntaxErrorCode2 = codes.ElementAtOrDefault(1)
            };
        }

        private static Eddy.x12.Models.v5010.AK9_FunctionalGroupResponseTrailer BuildAk9V5010(GroupAckInfo groupInfo, AcknowledgmentOptions options)
        {
            var codes = groupInfo.SyntaxCodes();
            return new Eddy.x12.Models.v5010.AK9_FunctionalGroupResponseTrailer
            {
                FunctionalGroupAcknowledgeCode = groupInfo.FunctionalGroupAckCode(options),
                NumberOfTransactionSetsIncluded = groupInfo.Transactions.Count,
                NumberOfReceivedTransactionSets = groupInfo.Transactions.Count,
                NumberOfAcceptedTransactionSets = groupInfo.Transactions.Count(t => t.AckCode(options) != "R"),
                FunctionalGroupSyntaxErrorCode = codes.ElementAtOrDefault(0),
                FunctionalGroupSyntaxErrorCode2 = codes.ElementAtOrDefault(1)
            };
        }

        private static int? ParseIntOrNull(string value)
        {
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsed) ? (int?)parsed : null;
        }
    }
}
