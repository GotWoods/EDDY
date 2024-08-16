using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E017")]
public class E017_MonetaryAmount : EdifactComponent
{
	[Position(1)]
	public string MonetaryAmountTypeQualifier { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string CurrencyCoded { get; set; }

	[Position(4)]
	public string CurrencyQualifier { get; set; }

	[Position(5)]
	public string StatusCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E017_MonetaryAmount>(this);
		validator.Length(x => x.MonetaryAmountTypeQualifier, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.CurrencyQualifier, 1, 3);
		validator.Length(x => x.StatusCoded, 1, 3);
		return validator.Results;
	}
}
