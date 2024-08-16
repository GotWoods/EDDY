using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98A.Composites;

[Segment("E977")]
public class E977_PaymentDetails : EdifactComponent
{
	[Position(1)]
	public string FormOfPaymentIdentification { get; set; }

	[Position(2)]
	public string PaymentTypeIdentification { get; set; }

	[Position(3)]
	public string ServiceToBePaidCoded { get; set; }

	[Position(4)]
	public string MonetaryAmount { get; set; }

	[Position(5)]
	public string CurrencyCoded { get; set; }

	[Position(6)]
	public string ReferenceNumber { get; set; }

	[Position(7)]
	public string Date { get; set; }

	[Position(8)]
	public string PlaceLocationIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E977_PaymentDetails>(this);
		validator.Length(x => x.FormOfPaymentIdentification, 1, 4);
		validator.Length(x => x.PaymentTypeIdentification, 1, 4);
		validator.Length(x => x.ServiceToBePaidCoded, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.ReferenceNumber, 1, 35);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		return validator.Results;
	}
}
