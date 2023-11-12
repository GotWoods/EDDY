using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

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
	public int? RepetitivePatternNumber { get; set; }

	[Position(05)]
	public string ReferencedPatternIdentifier { get; set; }

	[Position(06)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(07)]
	public string WeightUnitCode { get; set; }

	[Position(08)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(09)]
	public string StatusReportRequestCode { get; set; }

	[Position(10)]
	public string ShipmentQualifier { get; set; }

	[Position(11)]
	public string BillingCode { get; set; }

	[Position(12)]
	public string SectionSevenCode { get; set; }

	[Position(13)]
	public string CapacityLoadCode { get; set; }

	[Position(14)]
	public string ConfidentialBillingRequestCode { get; set; }

	[Position(15)]
	public string ReportTransmissionCode { get; set; }

	[Position(16)]
	public int? TotalEquipment { get; set; }

	[Position(17)]
	public string ShipmentWeightCode { get; set; }

	[Position(18)]
	public string CustomsDocumentationHandlingCode { get; set; }

	[Position(19)]
	public string TransportationTermsCode { get; set; }

	[Position(20)]
	public string PaymentMethodCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B2_BeginningSegmentForShipmentInformationTransaction>(this);
		validator.OnlyOneOf(x=>x.RepetitivePatternNumber, x=>x.ReferencedPatternIdentifier);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Length(x => x.TariffServiceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.RepetitivePatternNumber, 5);
		validator.Length(x => x.ReferencedPatternIdentifier, 1, 13);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.StatusReportRequestCode, 1);
		validator.Length(x => x.ShipmentQualifier, 1);
		validator.Length(x => x.BillingCode, 1);
		validator.Length(x => x.SectionSevenCode, 1);
		validator.Length(x => x.CapacityLoadCode, 1);
		validator.Length(x => x.ConfidentialBillingRequestCode, 1);
		validator.Length(x => x.ReportTransmissionCode, 1, 2);
		validator.Length(x => x.TotalEquipment, 1, 3);
		validator.Length(x => x.ShipmentWeightCode, 1);
		validator.Length(x => x.CustomsDocumentationHandlingCode, 2);
		validator.Length(x => x.TransportationTermsCode, 3);
		validator.Length(x => x.PaymentMethodCode, 3);
		return validator.Results;
	}
}
