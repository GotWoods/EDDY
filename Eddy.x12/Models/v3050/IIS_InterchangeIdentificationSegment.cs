using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("IIS")]
public class IIS_InterchangeIdentificationSegment : EdiX12Segment
{
	[Position(01)]
	public string ReportedInterchangeStartSegmentID { get; set; }

	[Position(02)]
	public string ReportedInterchangeControlNumber { get; set; }

	[Position(03)]
	public string ReportedInterchangeDate { get; set; }

	[Position(04)]
	public string ReportedInterchangeTime { get; set; }

	[Position(05)]
	public string ReportedInterchangeSenderIDQualifier { get; set; }

	[Position(06)]
	public string ReportedInterchangeSenderID { get; set; }

	[Position(07)]
	public string ReportedInterchangeReceiverIDQualifier { get; set; }

	[Position(08)]
	public string ReportedInterchangeReceiverID { get; set; }

	[Position(09)]
	public string FirstReferenceIDQualifier { get; set; }

	[Position(10)]
	public string FirstReferenceID { get; set; }

	[Position(11)]
	public string SecondReferenceIDQualifier { get; set; }

	[Position(12)]
	public string SecondReferenceID { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IIS_InterchangeIdentificationSegment>(this);
		validator.Required(x=>x.ReportedInterchangeStartSegmentID);
		validator.Required(x=>x.ReportedInterchangeControlNumber);
		validator.Required(x=>x.ReportedInterchangeDate);
		validator.Required(x=>x.ReportedInterchangeTime);
		validator.Required(x=>x.ReportedInterchangeSenderIDQualifier);
		validator.Required(x=>x.ReportedInterchangeSenderID);
		validator.Required(x=>x.ReportedInterchangeReceiverIDQualifier);
		validator.Required(x=>x.ReportedInterchangeReceiverID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FirstReferenceIDQualifier, x=>x.FirstReferenceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.SecondReferenceIDQualifier, x=>x.SecondReferenceID);
		validator.Length(x => x.ReportedInterchangeStartSegmentID, 2, 3);
		validator.Length(x => x.ReportedInterchangeControlNumber, 1, 14);
		validator.Length(x => x.ReportedInterchangeDate, 1, 8);
		validator.Length(x => x.ReportedInterchangeTime, 1, 8);
		validator.Length(x => x.ReportedInterchangeSenderIDQualifier, 1, 4);
		validator.Length(x => x.ReportedInterchangeSenderID, 1, 35);
		validator.Length(x => x.ReportedInterchangeReceiverIDQualifier, 1, 4);
		validator.Length(x => x.ReportedInterchangeReceiverID, 1, 35);
		validator.Length(x => x.FirstReferenceIDQualifier, 1, 4);
		validator.Length(x => x.FirstReferenceID, 1, 14);
		validator.Length(x => x.SecondReferenceIDQualifier, 1, 4);
		validator.Length(x => x.SecondReferenceID, 1, 14);
		return validator.Results;
	}
}
