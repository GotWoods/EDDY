using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E977")]
public class E977_PaymentDetails : EdifactComponent
{
	[Position(1)]
	public string PaymentMethodCode { get; set; }

	[Position(2)]
	public string PaymentPurposeCode { get; set; }

	[Position(3)]
	public string ServiceTypeCode { get; set; }

	[Position(4)]
	public string MonetaryAmount { get; set; }

	[Position(5)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(6)]
	public string ReferenceIdentifier { get; set; }

	[Position(7)]
	public string Date { get; set; }

	[Position(8)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E977_PaymentDetails>(this);
		validator.Length(x => x.PaymentMethodCode, 1, 4);
		validator.Length(x => x.PaymentPurposeCode, 1, 4);
		validator.Length(x => x.ServiceTypeCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.LocationIdentifier, 1, 35);
		return validator.Results;
	}
}
