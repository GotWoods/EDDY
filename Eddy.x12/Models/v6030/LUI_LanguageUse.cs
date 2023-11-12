using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("LUI")]
public class LUI_LanguageUse : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string UseOfLanguageIndicatorCode { get; set; }

	[Position(05)]
	public string LanguageProficiencyIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LUI_LanguageUse>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UseOfLanguageIndicatorCode, x=>x.IdentificationCode, x=>x.Description);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.UseOfLanguageIndicatorCode, 1, 2);
		validator.Length(x => x.LanguageProficiencyIndicatorCode, 1);
		return validator.Results;
	}
}
