using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C235")]
public class C235_HazardIdentification : EdifactComponent
{
	[Position(1)]
	public string HazardIdentificationNumberUpperPart { get; set; }

	[Position(2)]
	public string SubstanceIdentificationNumberLowerPart { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C235_HazardIdentification>(this);
		validator.Length(x => x.HazardIdentificationNumberUpperPart, 1, 4);
		validator.Length(x => x.SubstanceIdentificationNumberLowerPart, 4);
		return validator.Results;
	}
}
