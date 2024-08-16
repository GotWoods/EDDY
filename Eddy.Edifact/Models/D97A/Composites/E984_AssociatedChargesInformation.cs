using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E984")]
public class E984_AssociatedChargesInformation : EdifactComponent
{
	[Position(1)]
	public string ChargeUnitCoded { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string ItemDescription { get; set; }

	[Position(4)]
	public string Quantity { get; set; }

	[Position(5)]
	public string ChargePeriodTypeCoded { get; set; }

	[Position(6)]
	public string CurrencyCoded { get; set; }

	[Position(7)]
	public string PlaceLocationIdentification { get; set; }

	[Position(8)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E984_AssociatedChargesInformation>(this);
		validator.Length(x => x.ChargeUnitCoded, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ItemDescription, 1, 35);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ChargePeriodTypeCoded, 1, 3);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
