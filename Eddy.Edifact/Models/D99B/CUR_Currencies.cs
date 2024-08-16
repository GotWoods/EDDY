using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("CUR")]
public class CUR_Currencies : EdifactSegment
{
	[Position(1)]
	public E504_CurrencyDetails CurrencyDetails { get; set; }

	[Position(2)]
	public E504_CurrencyDetails CurrencyDetails2 { get; set; }

	[Position(3)]
	public string RateOfExchange { get; set; }

	[Position(4)]
	public string ExchangeRateCurrencyMarketIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CUR_Currencies>(this);
		validator.Length(x => x.RateOfExchange, 1, 12);
		validator.Length(x => x.ExchangeRateCurrencyMarketIdentifier, 1, 3);
		return validator.Results;
	}
}
