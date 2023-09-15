using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("B3")]
public class B3_BeginningSegmentForCarriersInvoice : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string InvoiceNumber { get; set; }

	[Position(03)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(04)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(05)]
	public string WeightUnitQualifier { get; set; }

	[Position(06)]
	public string BillingDate { get; set; }

	[Position(07)]
	public string NetAmountDue { get; set; }

	[Position(08)]
	public string CorrectionIndicator { get; set; }

	[Position(09)]
	public string DeliveryDate { get; set; }

	[Position(10)]
	public string DateTimeQualifier { get; set; }

	[Position(11)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(12)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B3_BeginningSegmentForCarriersInvoice>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Required(x=>x.BillingDate);
		validator.Required(x=>x.NetAmountDue);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.BillingDate, 6);
		validator.Length(x => x.NetAmountDue, 1, 9);
		validator.Length(x => x.CorrectionIndicator, 2);
		validator.Length(x => x.DeliveryDate, 6);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}