using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E984")]
public class E984_AssociatedChargesInformation : EdifactComponent
{
	[Position(1)]
	public string ChargeUnitCode { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string ItemDescription { get; set; }

	[Position(4)]
	public string Quantity { get; set; }

	[Position(5)]
	public string ChargePeriodTypeCode { get; set; }

	[Position(6)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(7)]
	public string LocationNameCode { get; set; }

	[Position(8)]
	public string FreeTextValue { get; set; }

	[Position(9)]
	public string MaintenanceOperationCode { get; set; }

	[Position(10)]
	public string RequirementDesignatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E984_AssociatedChargesInformation>(this);
		validator.Length(x => x.ChargeUnitCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.ItemDescription, 1, 256);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.ChargePeriodTypeCode, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.LocationNameCode, 1, 25);
		validator.Length(x => x.FreeTextValue, 1, 512);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		return validator.Results;
	}
}
