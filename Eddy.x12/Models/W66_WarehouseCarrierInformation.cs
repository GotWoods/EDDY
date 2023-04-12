using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("W66")]
public class W66_WarehouseCarrierInformation : EdiX12Segment
{
	[Position(01)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(02)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(03)]
	public string PalletExchangeCode { get; set; }

	[Position(04)]
	public string UnitLoadOptionCode { get; set; }

	[Position(05)]
	public string Routing { get; set; }

	[Position(06)]
	public string FOBPointCode { get; set; }

	[Position(07)]
	public string FOBPoint { get; set; }

	[Position(08)]
	public string CODMethodOfPaymentCode { get; set; }

	[Position(09)]
	public string Amount { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W66_WarehouseCarrierInformation>(this);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CODMethodOfPaymentCode, x=>x.Amount);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.PalletExchangeCode, 1);
		validator.Length(x => x.UnitLoadOptionCode, 2);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.FOBPointCode, 2);
		validator.Length(x => x.FOBPoint, 1, 30);
		validator.Length(x => x.CODMethodOfPaymentCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
