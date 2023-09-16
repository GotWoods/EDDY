using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SL1")]
public class SL1_TariffReference : EdiX12Segment
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
	public string EffectiveDate { get; set; }

	[Position(06)]
	public string ServiceLevelCode2 { get; set; }

	[Position(07)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(08)]
	public string DataSourceCode { get; set; }

	[Position(09)]
	public string InternationalDomesticCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SL1_TariffReference>(this);
		validator.Required(x=>x.ServiceLevelCode);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.Scale, 1, 10);
		validator.Length(x => x.EffectiveDate, 6);
		validator.Length(x => x.ServiceLevelCode2, 2);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.DataSourceCode, 2);
		validator.Length(x => x.InternationalDomesticCode, 1);
		return validator.Results;
	}
}
