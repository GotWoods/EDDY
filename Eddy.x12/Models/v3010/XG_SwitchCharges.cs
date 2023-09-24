using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

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
	public string Charge { get; set; }

	[Position(06)]
	public string SpecialChargeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XG_SwitchCharges>(this);
		validator.Required(x=>x.Charge);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.SpecialChargeCode, 3);
		return validator.Results;
	}
}
