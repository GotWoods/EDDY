using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TPD")]
public class TPD_TradingPartnerDetail : EdiX12Segment
{
	[Position(01)]
	public string ItemDescriptionTypeCode { get; set; }

	[Position(02)]
	public string CommodityCodeQualifier { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TPD_TradingPartnerDetail>(this);
		validator.Required(x=>x.ItemDescriptionTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.Length(x => x.ItemDescriptionTypeCode, 1);
		validator.Length(x => x.CommodityCodeQualifier, 1, 2);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
