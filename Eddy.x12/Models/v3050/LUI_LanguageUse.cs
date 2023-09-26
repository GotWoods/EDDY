using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("LUI")]
public class LUI_LanguageUse : EdiX12Segment
{
	[Position(01)]
	public string LanguageCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string UseOfLanguageIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LUI_LanguageUse>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UseOfLanguageIndicator, x=>x.LanguageCode, x=>x.Description);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.UseOfLanguageIndicator, 1, 2);
		return validator.Results;
	}
}
