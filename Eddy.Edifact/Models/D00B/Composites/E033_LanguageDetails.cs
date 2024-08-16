using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E033")]
public class E033_LanguageDetails : EdifactComponent
{
	[Position(1)]
	public string LanguageNameCode { get; set; }

	[Position(2)]
	public string LanguageName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E033_LanguageDetails>(this);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.LanguageName, 1, 35);
		return validator.Results;
	}
}
