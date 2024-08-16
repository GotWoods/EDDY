using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E015")]
public class E015_ProductDataInformation : EdifactComponent
{
	[Position(1)]
	public string ItemDescriptionIdentification { get; set; }

	[Position(2)]
	public string ItemDescription { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string MonetaryAmountValue { get; set; }

	[Position(5)]
	public string ChargePeriodTypeCoded { get; set; }

	[Position(6)]
	public string ChargeUnitCoded { get; set; }

	[Position(7)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(8)]
	public string InformationTypeIdentification { get; set; }

	[Position(9)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E015_ProductDataInformation>(this);
		validator.Length(x => x.ItemDescriptionIdentification, 1, 17);
		validator.Length(x => x.ItemDescription, 1, 256);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		validator.Length(x => x.ChargePeriodTypeCoded, 1, 3);
		validator.Length(x => x.ChargeUnitCoded, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.InformationTypeIdentification, 1, 4);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
