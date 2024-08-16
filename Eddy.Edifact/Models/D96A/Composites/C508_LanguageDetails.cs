using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C508")]
public class C508_LanguageDetails : EdifactComponent
{
	[Position(1)]
	public string LanguageCoded { get; set; }

	[Position(2)]
	public string Language { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C508_LanguageDetails>(this);
		validator.Length(x => x.LanguageCoded, 1, 3);
		validator.Length(x => x.Language, 1, 35);
		return validator.Results;
	}
}
