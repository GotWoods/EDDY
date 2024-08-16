using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C128")]
public class C128_RateDetails : EdifactComponent
{
	[Position(1)]
	public string RateTypeCodeQualifier { get; set; }

	[Position(2)]
	public string UnitPriceBasisRate { get; set; }

	[Position(3)]
	public string UnitPriceBasisValue { get; set; }

	[Position(4)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C128_RateDetails>(this);
		validator.Required(x=>x.RateTypeCodeQualifier);
		validator.Required(x=>x.UnitPriceBasisRate);
		validator.Length(x => x.RateTypeCodeQualifier, 1, 3);
		validator.Length(x => x.UnitPriceBasisRate, 1, 15);
		validator.Length(x => x.UnitPriceBasisValue, 1, 9);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		return validator.Results;
	}
}
