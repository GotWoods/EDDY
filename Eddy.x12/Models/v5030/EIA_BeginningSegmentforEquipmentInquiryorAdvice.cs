using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("EIA")]
public class EIA_BeginningSegmentForEquipmentInquiryOrAdvice : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(05)]
	public int? Count { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EIA_BeginningSegmentForEquipmentInquiryOrAdvice>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.ARequiresB(x=>x.Count, x=>x.YesNoConditionOrResponseCode3);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
