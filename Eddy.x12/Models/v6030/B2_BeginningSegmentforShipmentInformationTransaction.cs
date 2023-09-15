using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("B2")]
public class B2_BeginningSegmentForShipmentInformationTransaction : EdiX12Segment
{
	[Position(01)]
	public string TariffServiceCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string StandardPointLocationCode { get; set; }

	[Position(04)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(05)]
	public string WeightUnitCode { get; set; }

	[Position(06)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(07)]
	public string ShipmentQualifier { get; set; }

	[Position(08)]
	public int? TotalEquipment { get; set; }

	[Position(09)]
	public string ShipmentWeightCode { get; set; }

	[Position(10)]
	public string CustomsDocumentationHandlingCode { get; set; }

	[Position(11)]
	public string TransportationTermsCode { get; set; }

	[Position(12)]
	public string PaymentMethodCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B2_BeginningSegmentForShipmentInformationTransaction>(this);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Length(x => x.TariffServiceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.ShipmentQualifier, 1);
		validator.Length(x => x.TotalEquipment, 1, 3);
		validator.Length(x => x.ShipmentWeightCode, 1);
		validator.Length(x => x.CustomsDocumentationHandlingCode, 2);
		validator.Length(x => x.TransportationTermsCode, 3);
		validator.Length(x => x.PaymentMethodCode, 3);
		return validator.Results;
	}
}
