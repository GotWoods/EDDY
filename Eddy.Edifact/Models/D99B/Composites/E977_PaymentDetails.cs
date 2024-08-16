using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E977")]
public class E977_PaymentDetails : EdifactComponent
{
	[Position(1)]
	public string FormOfPaymentIdentification { get; set; }

	[Position(2)]
	public string PaymentTypeIdentification { get; set; }

	[Position(3)]
	public string ServiceTypeCode { get; set; }

	[Position(4)]
	public string MonetaryAmountValue { get; set; }

	[Position(5)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(6)]
	public string ReferenceIdentifier { get; set; }

	[Position(7)]
	public string DateValue { get; set; }

	[Position(8)]
	public string LocationNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E977_PaymentDetails>(this);
		validator.Length(x => x.FormOfPaymentIdentification, 1, 4);
		validator.Length(x => x.PaymentTypeIdentification, 1, 4);
		validator.Length(x => x.ServiceTypeCode, 1, 3);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.LocationNameCode, 1, 25);
		return validator.Results;
	}
}
