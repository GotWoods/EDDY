using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("FCL")]
public class FCL_Foreclosure : EdiX12Segment
{
	[Position(01)]
	public string DeficiencyJudgmentCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string AmountQualifierCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string AdjustmentReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FCL_Foreclosure>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.DeficiencyJudgmentCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		return validator.Results;
	}
}
