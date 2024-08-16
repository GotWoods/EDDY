using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("LNG")]
public class LNG_Language : EdifactSegment
{
	[Position(1)]
	public string LanguageCodeQualifier { get; set; }

	[Position(2)]
	public E033_LanguageDetails LanguageDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LNG_Language>(this);
		validator.Required(x=>x.LanguageCodeQualifier);
		validator.Length(x => x.LanguageCodeQualifier, 1, 3);
		return validator.Results;
	}
}
