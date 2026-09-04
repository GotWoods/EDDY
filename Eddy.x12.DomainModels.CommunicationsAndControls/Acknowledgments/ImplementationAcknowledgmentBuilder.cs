using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Eddy.x12;
using Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments.Internal;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments
{
    /// <summary>
    /// Builds a 999 Implementation Acknowledgment for an x12Document at version 005010 or higher that was parsed
    /// (typically leniently) so its ValidationErrors can be turned into IK3/IK4/IK5/AK9 detail. One 999
    /// (ST/AK1/[AK2 ...]/AK9/SE) is produced per functional group found in the input, each inside its own GS...GE,
    /// all inside a single ISA...IEA interchange mirrored back to the sender.
    /// </summary>
    public class ImplementationAcknowledgmentBuilder
    {
        public x12Document Build999(x12Document input, AcknowledgmentOptions options = null)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            options = options ?? new AcknowledgmentOptions();

            var inputHeader = input.Interchanges?.FirstOrDefault()?.Header ?? input.InterchangeControlHeader;
            if (inputHeader == null)
                throw new ArgumentException("The input document has no ISA header to acknowledge.", nameof(input));

            var groupInfos = AckSupport.BuildGroupAckInfos(input);

            if (groupInfos.Count == 0
                || groupInfos.Any(g => AckSupport.DetermineBucket(g.InputHeader?.VersionReleaseIndustryIdentifierCode) != AckVersionBucket.V5010))
            {
                throw new ArgumentException(
                    "A 999 Implementation Acknowledgment requires an input document at version 005010 or higher.",
                    nameof(input));
            }

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
                var body = BuildBody(groupInfo, options);

                var section = new Section
                {
                    SectionType = "999",
                    TransactionSetControlNumber = tsControlNumber,
                    Segments = body
                };
                functionalGroup.Sections.Add(section);
            }

            return output;
        }

        public string Build999Text(x12Document input, AcknowledgmentOptions options = null)
        {
            var document = Build999(input, options);

            var inputHeader = input?.Interchanges?.FirstOrDefault()?.Header ?? input?.InterchangeControlHeader;
            if (inputHeader == null)
                throw new ArgumentException("The input document has no ISA header to derive separators from.", nameof(input));

            var mapOptions = AckSupport.DeriveMapOptions(inputHeader);
            return document.ToString(mapOptions);
        }

        private static List<EdiX12Segment> BuildBody(GroupAckInfo groupInfo, AcknowledgmentOptions options)
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
                    // ImplementationConventionReference (AK203) intentionally left blank.
                });

                if (options.IncludeAK3AK4)
                {
                    foreach (var segmentError in transaction.SegmentErrors)
                    {
                        body.Add(new Eddy.x12.Models.v5010.IK3_ImplementationDataSegmentNote
                        {
                            SegmentIDCode = segmentError.SegmentIdCode,
                            SegmentPositionInTransactionSet = segmentError.SegmentPosition,
                            ImplementationSegmentSyntaxErrorCode = segmentError.SegmentErrorCode
                        });

                        // CTX (context) is optional and skipped -- we don't have enough loop/business context to
                        // populate it meaningfully.

                        foreach (var element in segmentError.Elements)
                        {
                            body.Add(new Eddy.x12.Models.v5010.IK4_ImplementationDataElementNote
                            {
                                PositionInSegment = new Eddy.x12.Models.v5010.Composites.C030_PositionInSegment { ElementPositionInSegment = element.ElementPosition },
                                ImplementationDataElementSyntaxErrorCode = element.ErrorCode,
                                CopyOfBadDataElement = element.BadValue
                            });
                        }
                    }
                }

                var codes = transaction.SyntaxCodes();
                body.Add(new Eddy.x12.Models.v5010.IK5_ImplementationTransactionSetResponseTrailer
                {
                    TransactionSetAcknowledgmentCode = transaction.AckCode(options),
                    ImplementationTransactionSetSyntaxErrorCode = codes.ElementAtOrDefault(0),
                    ImplementationTransactionSetSyntaxErrorCode2 = codes.ElementAtOrDefault(1),
                    ImplementationTransactionSetSyntaxErrorCode3 = codes.ElementAtOrDefault(2),
                    ImplementationTransactionSetSyntaxErrorCode4 = codes.ElementAtOrDefault(3),
                    ImplementationTransactionSetSyntaxErrorCode5 = codes.ElementAtOrDefault(4)
                });
            }

            var groupCodes = groupInfo.SyntaxCodes();
            body.Add(new Eddy.x12.Models.v5010.AK9_FunctionalGroupResponseTrailer
            {
                FunctionalGroupAcknowledgeCode = groupInfo.FunctionalGroupAckCode(options),
                NumberOfTransactionSetsIncluded = groupInfo.Transactions.Count,
                NumberOfReceivedTransactionSets = groupInfo.Transactions.Count,
                NumberOfAcceptedTransactionSets = groupInfo.Transactions.Count(t => t.AckCode(options) != "R"),
                FunctionalGroupSyntaxErrorCode = groupCodes.ElementAtOrDefault(0),
                FunctionalGroupSyntaxErrorCode2 = groupCodes.ElementAtOrDefault(1)
            });

            return body;
        }

        private static int? ParseIntOrNull(string value)
        {
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsed) ? (int?)parsed : null;
        }
    }
}
