using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C516")]
public class C516_MonetaryAmount : EdifactComponent
{
	[Position(1)]
	public string MonetaryAmountTypeCodeQualifier { get; set; }

	[Position(2)]
	public string MonetaryAmountValue { get; set; }

	[Position(3)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(4)]
	public string CurrencyQualifier { get; set; }

	[Position(5)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C516_MonetaryAmount>(this);
		validator.Required(x=>x.MonetaryAmountTypeCodeQualifier);
		validator.Length(x => x.MonetaryAmountTypeCodeQualifier, 1, 3);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.CurrencyQualifier, 1, 3);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}