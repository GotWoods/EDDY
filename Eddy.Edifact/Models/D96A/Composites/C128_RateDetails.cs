using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C128")]
public class C128_RateDetails : EdifactComponent
{
	[Position(1)]
	public string RateTypeQualifier { get; set; }

	[Position(2)]
	public string RatePerUnit { get; set; }

	[Position(3)]
	public string UnitPriceBasis { get; set; }

	[Position(4)]
	public string MeasureUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C128_RateDetails>(this);
		validator.Required(x=>x.RateTypeQualifier);
		validator.Required(x=>x.RatePerUnit);
		validator.Length(x => x.RateTypeQualifier, 1, 3);
		validator.Length(x => x.RatePerUnit, 1, 15);
		validator.Length(x => x.UnitPriceBasis, 1, 9);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		return validator.Results;
	}
}
