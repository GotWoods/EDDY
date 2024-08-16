using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C819")]
public class C819_CountrySubEntityDetails : EdifactComponent
{
	[Position(1)]
	public string CountrySubEntityNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string CountrySubEntityName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C819_CountrySubEntityDetails>(this);
		validator.Length(x => x.CountrySubEntityNameCode, 1, 9);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.CountrySubEntityName, 1, 35);
		return validator.Results;
	}
}
