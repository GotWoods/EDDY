using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

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
		return validator.Results;
	}
}
