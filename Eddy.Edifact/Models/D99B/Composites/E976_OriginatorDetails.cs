using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E976")]
public class E976_OriginatorDetails : EdifactComponent
{
	[Position(1)]
	public string CountryNameCode { get; set; }

	[Position(2)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(3)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E976_OriginatorDetails>(this);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}
