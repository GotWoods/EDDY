using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E015")]
public class E015_ProductDataInformation : EdifactComponent
{
	[Position(1)]
	public string ItemDescriptionCode { get; set; }

	[Position(2)]
	public string ItemDescription { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string MonetaryAmount { get; set; }

	[Position(5)]
	public string ChargePeriodTypeCode { get; set; }

	[Position(6)]
	public string ChargeUnitCode { get; set; }

	[Position(7)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(8)]
	public string InformationTypeCode { get; set; }

	[Position(9)]
	public string FreeText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E015_ProductDataInformation>(this);
		validator.Length(x => x.ItemDescriptionCode, 1, 17);
		validator.Length(x => x.ItemDescription, 1, 256);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.ChargePeriodTypeCode, 1, 3);
		validator.Length(x => x.ChargeUnitCode, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.InformationTypeCode, 1, 4);
		validator.Length(x => x.FreeText, 1, 512);
		return validator.Results;
	}
}
