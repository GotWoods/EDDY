using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("SL1")]
public class SL1_TariffDetails : EdiX12Segment
{
	[Position(01)]
	public string ServiceLevelCode { get; set; }

	[Position(02)]
	public string TariffNumber { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string Scale { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string ServiceLevelCode2 { get; set; }

	[Position(07)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(08)]
	public string DataSourceCode { get; set; }

	[Position(09)]
	public string InternationalDomesticCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SL1_TariffDetails>(this);
		validator.Required(x=>x.ServiceLevelCode);
		validator.AtLeastOneIsRequired(x=>x.CommodityCode, x=>x.Scale);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.Scale, 1, 10);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ServiceLevelCode2, 2);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.DataSourceCode, 2);
		validator.Length(x => x.InternationalDomesticCode, 1);
		return validator.Results;
	}
}
