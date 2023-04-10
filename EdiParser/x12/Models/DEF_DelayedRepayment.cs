using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DEF")]
public class DEF_DelayedRepayment : EdiX12Segment
{
	[Position(01)]
	public string DelayedRepaymentQualifierCode { get; set; }

	[Position(02)]
	public string DelayedRepaymentReasonCode { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string InterestPaymentCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEF_DelayedRepayment>(this);
		validator.Required(x=>x.DelayedRepaymentQualifierCode);
		validator.Required(x=>x.DelayedRepaymentReasonCode);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Length(x => x.DelayedRepaymentQualifierCode, 1);
		validator.Length(x => x.DelayedRepaymentReasonCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.InterestPaymentCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
