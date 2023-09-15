using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BX")]
public class BX_GeneralShipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(03)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(04)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string WeightUnitQualifier { get; set; }

	[Position(07)]
	public string ShipmentQualifier { get; set; }

	[Position(08)]
	public string SectionSevenCode { get; set; }

	[Position(09)]
	public string CapacityLoadCode { get; set; }

	[Position(10)]
	public string StatusReportRequestCode { get; set; }

	[Position(11)]
	public string CustomsDocumentationHandlingCode { get; set; }

	[Position(12)]
	public string ConfidentialBillingRequestCode { get; set; }

	[Position(13)]
	public string GoodsAndServicesTaxReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BX_GeneralShipmentInformation>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.ShipmentQualifier, 1);
		validator.Length(x => x.SectionSevenCode, 1);
		validator.Length(x => x.CapacityLoadCode, 1);
		validator.Length(x => x.StatusReportRequestCode, 1);
		validator.Length(x => x.CustomsDocumentationHandlingCode, 2);
		validator.Length(x => x.ConfidentialBillingRequestCode, 1);
		validator.Length(x => x.GoodsAndServicesTaxReasonCode, 1);
		return validator.Results;
	}
}
