using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("NUN")]
public class NUN_NumberOfUnits : EdifactSegment
{
	[Position(1)]
	public E523_NumberOfUnitDetails NumberOfUnitDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NUN_NumberOfUnits>(this);
		validator.Required(x=>x.NumberOfUnitDetails);
		return validator.Results;
	}
}
