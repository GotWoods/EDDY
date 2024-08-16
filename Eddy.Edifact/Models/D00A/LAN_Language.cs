using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("LAN")]
public class LAN_Language : EdifactSegment
{
	[Position(1)]
	public string LanguageCodeQualifier { get; set; }

	[Position(2)]
	public C508_LanguageDetails LanguageDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LAN_Language>(this);
		validator.Required(x=>x.LanguageCodeQualifier);
		validator.Length(x => x.LanguageCodeQualifier, 1, 3);
		return validator.Results;
	}
}
