using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("CNY")]
public class CNY_CountryInformation : EdifactSegment
{
	[Position(1)]
	public string CountryNameCode { get; set; }

	[Position(2)]
	public E013_DateAndTimeInformation DateAndTimeInformation { get; set; }

	[Position(3)]
	public string TimeVariationQuantity { get; set; }

	[Position(4)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(5)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CNY_CountryInformation>(this);
		validator.Required(x=>x.CountryNameCode);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.TimeVariationQuantity, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}
