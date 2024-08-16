using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C553")]
public class C553_RelatedLocationTwoIdentification : EdifactComponent
{
	[Position(1)]
	public string RelatedPlaceLocationTwoIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string RelatedPlaceLocationTwo { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C553_RelatedLocationTwoIdentification>(this);
		validator.Length(x => x.RelatedPlaceLocationTwoIdentification, 1, 25);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.RelatedPlaceLocationTwo, 1, 70);
		return validator.Results;
	}
}
