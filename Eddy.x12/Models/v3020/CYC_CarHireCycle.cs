using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CYC")]
public class CYC_CarHireCycle : EdiX12Segment
{
	[Position(01)]
	public int? Century { get; set; }

	[Position(02)]
	public int? YearWithinCentury { get; set; }

	[Position(03)]
	public string MonthOfTheYearCode { get; set; }

	[Position(04)]
	public int? CycleMonthHours { get; set; }

	[Position(05)]
	public string StandardPointLocationCode { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(07)]
	public string AssociationOfAmericanRailroadsAARPoolCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CYC_CarHireCycle>(this);
		validator.Required(x=>x.Century);
		validator.Required(x=>x.YearWithinCentury);
		validator.Required(x=>x.MonthOfTheYearCode);
		validator.Required(x=>x.CycleMonthHours);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.YearWithinCentury, 2);
		validator.Length(x => x.MonthOfTheYearCode, 2);
		validator.Length(x => x.CycleMonthHours, 1, 3);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.AssociationOfAmericanRailroadsAARPoolCode, 7);
		return validator.Results;
	}
}
