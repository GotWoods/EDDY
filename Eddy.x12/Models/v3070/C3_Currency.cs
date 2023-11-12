using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("C3")]
public class C3_Currency : EdiX12Segment
{
	[Position(01)]
	public string CurrencyCode { get; set; }

	[Position(02)]
	public decimal? ExchangeRate { get; set; }

	[Position(03)]
	public string CurrencyCode2 { get; set; }

	[Position(04)]
	public string CurrencyCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C3_Currency>(this);
		validator.Required(x=>x.CurrencyCode);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.ExchangeRate, 4, 10);
		validator.Length(x => x.CurrencyCode2, 3);
		validator.Length(x => x.CurrencyCode3, 3);
		return validator.Results;
	}
}
