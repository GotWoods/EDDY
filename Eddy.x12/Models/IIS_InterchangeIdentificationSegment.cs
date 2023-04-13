using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IIS")]
public class IIS_InterchangeIdentificationSegment : EdiX12Segment
{
	[Position(01)]
	public string ReportedStartSegmentID { get; set; }

	[Position(02)]
	public string ReportedControlNumber { get; set; }

	[Position(03)]
	public string ReportedDate { get; set; }

	[Position(04)]
	public string ReportedTime { get; set; }

	[Position(05)]
	public string ReportedInterchangeSenderIDQualifier { get; set; }

	[Position(06)]
	public string ReportedSenderID { get; set; }

	[Position(07)]
	public string ReportedInterchangeReceiverIDQualifier { get; set; }

	[Position(08)]
	public string ReportedReceiverID { get; set; }

	[Position(09)]
	public string FirstReferenceIDQualifier { get; set; }

	[Position(10)]
	public string FirstReferenceID { get; set; }

	[Position(11)]
	public string SecondReferenceIDQualifier { get; set; }

	[Position(12)]
	public string SecondReferenceID { get; set; }

	[Position(13)]
	public string InterchangeMessageDirectionCode { get; set; }

	[Position(14)]
	public string ReportedGroupOrTransactionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IIS_InterchangeIdentificationSegment>(this);
		validator.Length(x => x.ReportedStartSegmentID, 2, 3);
		validator.Length(x => x.ReportedControlNumber, 1, 14);
		validator.Length(x => x.ReportedDate, 1, 8);
		validator.Length(x => x.ReportedTime, 1, 8);
		validator.Length(x => x.ReportedInterchangeSenderIDQualifier, 1, 4);
		validator.Length(x => x.ReportedSenderID, 1, 35);
		validator.Length(x => x.ReportedInterchangeReceiverIDQualifier, 1, 4);
		validator.Length(x => x.ReportedReceiverID, 1, 35);
		validator.Length(x => x.FirstReferenceIDQualifier, 1, 4);
		validator.Length(x => x.FirstReferenceID, 1, 14);
		validator.Length(x => x.SecondReferenceIDQualifier, 1, 4);
		validator.Length(x => x.SecondReferenceID, 1, 14);
		validator.Length(x => x.InterchangeMessageDirectionCode, 1);
		validator.Length(x => x.ReportedGroupOrTransactionIdentifier, 2, 6);
		return validator.Results;
	}
}
