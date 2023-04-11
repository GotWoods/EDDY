using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CPR")]
public class CPR_CommodityPriceReference : EdiX12Segment
{
	[Position(01)]
	public string MarketExchangeIdentifierCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public decimal? UnitPrice { get; set; }

	[Position(04)]
	public string CommodityIdentificationCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPR_CommodityPriceReference>(this);
		validator.Required(x=>x.MarketExchangeIdentifierCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.UnitPrice);
		validator.Required(x=>x.CommodityIdentificationCode);
		validator.Length(x => x.MarketExchangeIdentifierCode, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.CommodityIdentificationCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
