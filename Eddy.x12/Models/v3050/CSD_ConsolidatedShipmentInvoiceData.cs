using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CSD")]
public class CSD_ConsolidatedShipmentInvoiceData : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string Charge { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(09)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSD_ConsolidatedShipmentInvoiceData>(this);
		validator.Required(x=>x.SpecialHandlingCode);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.Charge);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
