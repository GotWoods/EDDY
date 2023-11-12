using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("XG")]
public class XG_SwitchCharges : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public decimal? Rate { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XG_SwitchCharges>(this);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		return validator.Results;
	}
}
