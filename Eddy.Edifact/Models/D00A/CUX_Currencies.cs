using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CUX")]
public class CUX_Currencies : EdifactSegment
{
	[Position(1)]
	public C504_CurrencyDetails CurrencyDetails { get; set; }

	[Position(2)]
	public C504_CurrencyDetails CurrencyDetails2 { get; set; }

	[Position(3)]
	public string CurrencyExchangeRate { get; set; }

	[Position(4)]
	public string ExchangeRateCurrencyMarketIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CUX_Currencies>(this);
		validator.Length(x => x.CurrencyExchangeRate, 1, 12);
		validator.Length(x => x.ExchangeRateCurrencyMarketIdentifier, 1, 3);
		return validator.Results;
	}
}
