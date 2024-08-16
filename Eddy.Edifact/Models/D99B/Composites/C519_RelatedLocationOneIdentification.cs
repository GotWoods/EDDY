using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C519")]
public class C519_RelatedLocationOneIdentification : EdifactComponent
{
	[Position(1)]
	public string RelatedPlaceLocationOneIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RelatedPlaceLocationOne { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C519_RelatedLocationOneIdentification>(this);
		validator.Length(x => x.RelatedPlaceLocationOneIdentification, 1, 25);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RelatedPlaceLocationOne, 1, 70);
		return validator.Results;
	}
}
