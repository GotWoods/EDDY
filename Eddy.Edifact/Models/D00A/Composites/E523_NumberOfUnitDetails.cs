using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E523")]
public class E523_NumberOfUnitDetails : EdifactComponent
{
	[Position(1)]
	public string UnitsQuantity { get; set; }

	[Position(2)]
	public string UnitTypeCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E523_NumberOfUnitDetails>(this);
		validator.Length(x => x.UnitsQuantity, 1, 15);
		validator.Length(x => x.UnitTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
