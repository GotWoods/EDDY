using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("SAC")]
public class SAC_ServicePromotionAllowanceOrChargeInformation : EdiX12Segment
{
	[Position(01)]
	public string AllowanceOrChargeIndicator { get; set; }

	[Position(02)]
	public string ServicePromotionAllowanceOrChargeCode { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string AgencyServicePromotionAllowanceOrChargeCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string AllowanceChargePercentQualifier { get; set; }

	[Position(07)]
	public decimal? Percent { get; set; }

	[Position(08)]
	public decimal? Rate { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public decimal? Quantity2 { get; set; }

	[Position(12)]
	public string AllowanceOrChargeMethodOfHandlingCode { get; set; }

	[Position(13)]
	public string ReferenceIdentification { get; set; }

	[Position(14)]
	public string OptionNumber { get; set; }

	[Position(15)]
	public string Description { get; set; }

	[Position(16)]
	public string LanguageCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SAC_ServicePromotionAllowanceOrChargeInformation>(this);
		validator.Required(x=>x.AllowanceOrChargeIndicator);
		validator.AtLeastOneIsRequired(x=>x.ServicePromotionAllowanceOrChargeCode, x=>x.AgencyQualifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.AgencyServicePromotionAllowanceOrChargeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AllowanceChargePercentQualifier, x=>x.Percent);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.ARequiresB(x=>x.Quantity2, x=>x.Quantity);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ReferenceIdentification, x=>x.ServicePromotionAllowanceOrChargeCode, x=>x.AgencyServicePromotionAllowanceOrChargeCode);
		validator.ARequiresB(x=>x.OptionNumber, x=>x.ReferenceIdentification);
		validator.ARequiresB(x=>x.LanguageCode, x=>x.Description);
		validator.Length(x => x.AllowanceOrChargeIndicator, 1);
		validator.Length(x => x.ServicePromotionAllowanceOrChargeCode, 4);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.AgencyServicePromotionAllowanceOrChargeCode, 1, 10);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.AllowanceChargePercentQualifier, 1);
		validator.Length(x => x.Percent, 1, 6);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.AllowanceOrChargeMethodOfHandlingCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.OptionNumber, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.LanguageCode, 2, 3);
		return validator.Results;
	}
}
