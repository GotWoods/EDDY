using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TA3")]
public class TA3_InterchangeDeliveryNoticeSegment : EdiX12Segment
{
	[Position(01)]
	public string ServiceRequestHandlerIDQualifier { get; set; }

	[Position(02)]
	public string ServiceRequestHandlerID { get; set; }

	[Position(03)]
	public string ErrorReasonCode { get; set; }

	[Position(04)]
	public string ReportedStartSegmentID { get; set; }

	[Position(05)]
	public string ReportedControlNumber { get; set; }

	[Position(06)]
	public string ReportedDate { get; set; }

	[Position(07)]
	public string ReportedTime { get; set; }

	[Position(08)]
	public string ReportedInterchangeSenderIDQualifier { get; set; }

	[Position(09)]
	public string ReportedSenderID { get; set; }

	[Position(10)]
	public string ReportedInterchangeReceiverIDQualifier { get; set; }

	[Position(11)]
	public string ReportedReceiverID { get; set; }

	[Position(12)]
	public string InterchangeActionCode { get; set; }

	[Position(13)]
	public string InterchangeActionDate { get; set; }

	[Position(14)]
	public string InterchangeActionTime { get; set; }

	[Position(15)]
	public string InterchangeActionCode2 { get; set; }

	[Position(16)]
	public string InterchangeActionDate2 { get; set; }

	[Position(17)]
	public string InterchangeActionTime2 { get; set; }

	[Position(18)]
	public string FirstReferenceIDQualifier { get; set; }

	[Position(19)]
	public string FirstReferenceID { get; set; }

	[Position(20)]
	public string SecondReferenceIDQualifier { get; set; }

	[Position(21)]
	public string SecondReferenceID { get; set; }

	[Position(22)]
	public string ReferenceCodeQualifier { get; set; }

	[Position(23)]
	public string ReferenceCode { get; set; }

	[Position(24)]
	public string ReferenceCodeQualifier2 { get; set; }

	[Position(25)]
	public string ReferenceCode2 { get; set; }

	[Position(26)]
	public string ReferenceCodeQualifier3 { get; set; }

	[Position(27)]
	public string ReferenceCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TA3_InterchangeDeliveryNoticeSegment>(this);
		validator.Required(x=>x.ServiceRequestHandlerIDQualifier);
		validator.Required(x=>x.ServiceRequestHandlerID);
		validator.Required(x=>x.ErrorReasonCode);
		validator.Required(x=>x.ReportedStartSegmentID);
		validator.Required(x=>x.ReportedControlNumber);
		validator.Required(x=>x.ReportedDate);
		validator.Required(x=>x.ReportedTime);
		validator.Required(x=>x.ReportedInterchangeSenderIDQualifier);
		validator.Required(x=>x.ReportedSenderID);
		validator.Required(x=>x.ReportedInterchangeReceiverIDQualifier);
		validator.Required(x=>x.ReportedReceiverID);
		validator.Required(x=>x.InterchangeActionCode);
		validator.Required(x=>x.InterchangeActionDate);
		validator.Required(x=>x.InterchangeActionTime);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceCodeQualifier, x=>x.ReferenceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceCodeQualifier2, x=>x.ReferenceCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceCodeQualifier3, x=>x.ReferenceCode3);
		validator.Length(x => x.ServiceRequestHandlerIDQualifier, 2);
		validator.Length(x => x.ServiceRequestHandlerID, 1, 15);
		validator.Length(x => x.ErrorReasonCode, 3);
		validator.Length(x => x.ReportedStartSegmentID, 2, 3);
		validator.Length(x => x.ReportedControlNumber, 1, 14);
		validator.Length(x => x.ReportedDate, 1, 8);
		validator.Length(x => x.ReportedTime, 1, 8);
		validator.Length(x => x.ReportedInterchangeSenderIDQualifier, 1, 4);
		validator.Length(x => x.ReportedSenderID, 1, 35);
		validator.Length(x => x.ReportedInterchangeReceiverIDQualifier, 1, 4);
		validator.Length(x => x.ReportedReceiverID, 1, 35);
		validator.Length(x => x.InterchangeActionCode, 2);
		validator.Length(x => x.InterchangeActionDate, 6);
		validator.Length(x => x.InterchangeActionTime, 4, 6);
		validator.Length(x => x.InterchangeActionCode2, 2);
		validator.Length(x => x.InterchangeActionDate2, 6);
		validator.Length(x => x.InterchangeActionTime2, 4, 6);
		validator.Length(x => x.FirstReferenceIDQualifier, 1, 4);
		validator.Length(x => x.FirstReferenceID, 1, 14);
		validator.Length(x => x.SecondReferenceIDQualifier, 1, 4);
		validator.Length(x => x.SecondReferenceID, 1, 14);
		validator.Length(x => x.ReferenceCodeQualifier, 2);
		validator.Length(x => x.ReferenceCode, 1, 35);
		validator.Length(x => x.ReferenceCodeQualifier2, 2);
		validator.Length(x => x.ReferenceCode2, 1, 35);
		validator.Length(x => x.ReferenceCodeQualifier3, 2);
		validator.Length(x => x.ReferenceCode3, 1, 35);
		return validator.Results;
	}
}
