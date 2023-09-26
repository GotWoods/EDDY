using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("CSD")]
public class CSD_ConsolidatedShipmentInvoiceData : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

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
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSD_ConsolidatedShipmentInvoiceData>(this);
		validator.Required(x=>x.SpecialHandlingCode);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Required(x=>x.Charge);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Charge, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		return validator.Results;
	}
}
