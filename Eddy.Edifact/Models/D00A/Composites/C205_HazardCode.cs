using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C205")]
public class C205_HazardCode : EdifactComponent
{
	[Position(1)]
	public string HazardIdentificationCode { get; set; }

	[Position(2)]
	public string AdditionalHazardClassificationIdentifier { get; set; }

	[Position(3)]
	public string HazardCodeVersionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C205_HazardCode>(this);
		validator.Required(x=>x.HazardIdentificationCode);
		validator.Length(x => x.HazardIdentificationCode, 1, 7);
		validator.Length(x => x.AdditionalHazardClassificationIdentifier, 1, 7);
		validator.Length(x => x.HazardCodeVersionIdentifier, 1, 10);
		return validator.Results;
	}
}
