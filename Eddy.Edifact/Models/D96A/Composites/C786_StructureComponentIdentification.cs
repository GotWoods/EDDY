using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C786")]
public class C786_StructureComponentIdentification : EdifactComponent
{
	[Position(1)]
	public string StructureComponentIdentifier { get; set; }

	[Position(2)]
	public string IdentityNumberQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C786_StructureComponentIdentification>(this);
		validator.Required(x=>x.StructureComponentIdentifier);
		validator.Length(x => x.StructureComponentIdentifier, 1, 35);
		validator.Length(x => x.IdentityNumberQualifier, 1, 3);
		return validator.Results;
	}
}
