using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E017")]
public class E017_MonetaryAmount : EdifactComponent
{
	[Position(1)]
	public string MonetaryAmountTypeCodeQualifier { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(4)]
	public string CurrencyTypeCodeQualifier { get; set; }

	[Position(5)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E017_MonetaryAmount>(this);
		validator.Length(x => x.MonetaryAmountTypeCodeQualifier, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.CurrencyTypeCodeQualifier, 1, 3);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
