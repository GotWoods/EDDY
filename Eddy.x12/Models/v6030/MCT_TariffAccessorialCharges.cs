using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("MCT")]
public class MCT_TariffAccessorialCharges : EdiX12Segment
{
	[Position(01)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(02)]
	public string TariffValueCode { get; set; }

	[Position(03)]
	public decimal? RangeMinimum { get; set; }

	[Position(04)]
	public decimal? RangeMaximum { get; set; }

	[Position(05)]
	public string RateValueQualifier { get; set; }

	[Position(06)]
	public decimal? Rate { get; set; }

	[Position(07)]
	public string TariffReferenceFlagCode { get; set; }

	[Position(08)]
	public string SpecialChargeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MCT_TariffAccessorialCharges>(this);
		validator.Required(x=>x.SpecialChargeOrAllowanceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.Rate);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.TariffValueCode, 2);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.TariffReferenceFlagCode, 1);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		return validator.Results;
	}
}
