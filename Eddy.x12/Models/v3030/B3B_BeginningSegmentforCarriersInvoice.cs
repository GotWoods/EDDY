using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("B3B")]
public class B3B_BeginningSegmentForCarriersInvoice : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string ShipmentMethodOfPayment { get; set; }

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
	public string CorrectionIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B3B_BeginningSegmentForCarriersInvoice>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.NetAmountDue);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.NetAmountDue, 1, 9);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.CorrectionIndicator, 2);
		return validator.Results;
	}
}
