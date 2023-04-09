using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("B3B")]
public class B3B_BeginningSegmentForRailCarriersInvoice : EdiX12Segment 
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string NetAmountDue { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(07)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(08)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(09)]
	public string WeightUnitCode { get; set; }

	[Position(10)]
	public string CorrectionIndicatorCode { get; set; }

	[Position(11)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B3B_BeginningSegmentForRailCarriersInvoice>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.NetAmountDue);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.NetAmountDue, 1, 15);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.CorrectionIndicatorCode, 2);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
