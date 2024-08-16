using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E819")]
public class E819_CountrySubEntityDetails : EdifactComponent
{
	[Position(1)]
	public string CountrySubEntityIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string CountrySubEntity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E819_CountrySubEntityDetails>(this);
		validator.Length(x => x.CountrySubEntityIdentification, 1, 9);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.CountrySubEntity, 1, 35);
		return validator.Results;
	}
}
