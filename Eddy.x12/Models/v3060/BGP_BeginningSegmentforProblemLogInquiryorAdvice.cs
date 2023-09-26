using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("BGP")]
public class BGP_BeginningSegmentForProblemLogInquiryOrAdvice : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ProblemLogReasonCode { get; set; }

	[Position(03)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string EquipmentInitial { get; set; }

	[Position(06)]
	public string EquipmentNumber { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	[Position(08)]
	public string StandardPointLocationCode { get; set; }

	[Position(09)]
	public string InterchangeTrainIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BGP_BeginningSegmentForProblemLogInquiryOrAdvice>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ProblemLogReasonCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ProblemLogReasonCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		return validator.Results;
	}
}
