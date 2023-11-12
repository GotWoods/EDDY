using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8020.Composites;

[Segment("C077")]
public class C077_CompositeCurrency : EdiX12Component
{
	[Position(00)]
	public decimal? UnitPrice { get; set; }

	[Position(01)]
	public string CurrencyCode { get; set; }

	[Position(02)]
	public decimal? UnitPrice2 { get; set; }

	[Position(03)]
	public string CurrencyCode2 { get; set; }

	[Position(04)]
	public decimal? UnitPrice3 { get; set; }

	[Position(05)]
	public string CurrencyCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C077_CompositeCurrency>(this);
		validator.Required(x=>x.UnitPrice);
		validator.Required(x=>x.CurrencyCode);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.UnitPrice2, 1, 17);
		validator.Length(x => x.CurrencyCode2, 3);
		validator.Length(x => x.UnitPrice3, 1, 17);
		validator.Length(x => x.CurrencyCode3, 3);
		return validator.Results;
	}
}
