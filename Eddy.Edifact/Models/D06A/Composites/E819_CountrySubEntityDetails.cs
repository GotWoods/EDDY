using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E819")]
public class E819_CountrySubEntityDetails : EdifactComponent
{
	[Position(1)]
	public string CountrySubdivisionIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string CountrySubdivisionName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E819_CountrySubEntityDetails>(this);
		validator.Length(x => x.CountrySubdivisionIdentifier, 1, 9);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.CountrySubdivisionName, 1, 70);
		return validator.Results;
	}
}
