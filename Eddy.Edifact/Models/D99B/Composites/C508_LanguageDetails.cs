using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C508")]
public class C508_LanguageDetails : EdifactComponent
{
	[Position(1)]
	public string LanguageNameCode { get; set; }

	[Position(2)]
	public string LanguageName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C508_LanguageDetails>(this);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.LanguageName, 1, 35);
		return validator.Results;
	}
}
