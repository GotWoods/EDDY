using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CUX")]
public class CUX_Currencies : EdifactSegment
{
	[Position(1)]
	public C504_CurrencyDetails CurrencyDetails { get; set; }

	[Position(2)]
	public C504_CurrencyDetails CurrencyDetails2 { get; set; }

	[Position(3)]
	public string RateOfExchange { get; set; }

	[Position(4)]
	public string CurrencyMarketExchangeCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CUX_Currencies>(this);
		validator.Length(x => x.RateOfExchange, 1, 12);
		validator.Length(x => x.CurrencyMarketExchangeCoded, 1, 3);
		return validator.Results;
	}
}