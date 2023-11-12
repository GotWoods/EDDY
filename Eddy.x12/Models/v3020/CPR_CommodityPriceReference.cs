using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CPR")]
public class CPR_CommodityPriceReference : EdiX12Segment
{
	[Position(01)]
	public string MarketExchangeIdentifier { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public decimal? UnitPrice { get; set; }

	[Position(04)]
	public string CommodityIdentification { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPR_CommodityPriceReference>(this);
		validator.Required(x=>x.MarketExchangeIdentifier);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.UnitPrice);
		validator.Required(x=>x.CommodityIdentification);
		validator.Length(x => x.MarketExchangeIdentifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.CommodityIdentification, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
