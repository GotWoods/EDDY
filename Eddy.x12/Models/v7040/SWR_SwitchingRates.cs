using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7040;

[Segment("SWR")]
public class SWR_SwitchingRates : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public decimal? Rate { get; set; }

	[Position(03)]
	public decimal? Rate2 { get; set; }

	[Position(04)]
	public string AmountCharged { get; set; }

	[Position(05)]
	public string AmountQualifierCode { get; set; }

	[Position(06)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(07)]
	public string RateValueQualifier2 { get; set; }

	[Position(08)]
	public string AmountCharged2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SWR_SwitchingRates>(this);
		validator.Required(x=>x.RateValueQualifier);
		validator.Required(x=>x.Rate);
		validator.Required(x=>x.Rate2);
		validator.Required(x=>x.AmountCharged);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.SpecialChargeOrAllowanceCode);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.Rate2, 1, 9);
		validator.Length(x => x.AmountCharged, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.AmountCharged2, 1, 15);
		return validator.Results;
	}
}
