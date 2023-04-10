using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

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
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string AmountCharged { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(09)]
	public string ReferenceIdentification2 { get; set; }

	[Position(10)]
	public string Time { get; set; }

	[Position(11)]
	public string TimeCode { get; set; }

	[Position(12)]
	public string Time2 { get; set; }

	[Position(13)]
	public string TimeCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSD_ConsolidatedShipmentInvoiceData>(this);
		validator.Required(x=>x.SpecialHandlingCode);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Required(x=>x.AmountCharged);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Time, x=>x.TimeCode);
		validator.ARequiresB(x=>x.Time, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Time2, x=>x.TimeCode2);
		validator.ARequiresB(x=>x.Time2, x=>x.Date2);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.AmountCharged, 1, 15);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TimeCode2, 2);
		return validator.Results;
	}
}
