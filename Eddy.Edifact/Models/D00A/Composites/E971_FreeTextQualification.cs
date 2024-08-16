using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E971")]
public class E971_FreeTextQualification : EdifactComponent
{
	[Position(1)]
	public string TextSubjectCodeQualifier { get; set; }

	[Position(2)]
	public string InformationTypeCode { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E971_FreeTextQualification>(this);
		validator.Required(x=>x.TextSubjectCodeQualifier);
		validator.Length(x => x.TextSubjectCodeQualifier, 1, 3);
		validator.Length(x => x.InformationTypeCode, 1, 4);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}
