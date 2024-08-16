using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E971")]
public class E971_FreeTextQualification : EdifactComponent
{
	[Position(1)]
	public string TextSubjectQualifier { get; set; }

	[Position(2)]
	public string InformationTypeIdentification { get; set; }

	[Position(3)]
	public string StatusCoded { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E971_FreeTextQualification>(this);
		validator.Required(x=>x.TextSubjectQualifier);
		validator.Length(x => x.TextSubjectQualifier, 1, 3);
		validator.Length(x => x.InformationTypeIdentification, 1, 4);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
