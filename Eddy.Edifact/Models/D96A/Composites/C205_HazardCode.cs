using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C205")]
public class C205_HazardCode : EdifactComponent
{
	[Position(1)]
	public string HazardCodeIdentification { get; set; }

	[Position(2)]
	public string HazardSubstanceItemPageNumber { get; set; }

	[Position(3)]
	public string HazardCodeVersionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C205_HazardCode>(this);
		validator.Required(x=>x.HazardCodeIdentification);
		validator.Length(x => x.HazardCodeIdentification, 1, 7);
		validator.Length(x => x.HazardSubstanceItemPageNumber, 1, 7);
		validator.Length(x => x.HazardCodeVersionNumber, 1, 10);
		return validator.Results;
	}
}
