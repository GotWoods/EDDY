using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

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
	public string AgencyServicePromotionAllowanceOrChangeCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public string AllowanceChargePercentQualifier { get; set; }

	[Position(07)]
	public decimal? AllowanceOrChargePercent { get; set; }

	[Position(08)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(10)]
	public decimal? AllowanceOrChargeQuantity { get; set; }

	[Position(11)]
	public decimal? AllowanceOrChargeQuantity2 { get; set; }

	[Position(12)]
	public string AllowanceOrChargeMethodOfHandlingCode { get; set; }

	[Position(13)]
	public string ReferenceNumber { get; set; }

	[Position(14)]
	public string OptionNumber { get; set; }

	[Position(15)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SAC_ServicePromotionAllowanceOrChargeInformation>(this);
		validator.Required(x=>x.AllowanceOrChargeIndicator);
		validator.AtLeastOneIsRequired(x=>x.ServicePromotionAllowanceOrChargeCode, x=>x.AgencyQualifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.AgencyServicePromotionAllowanceOrChangeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AllowanceChargePercentQualifier, x=>x.AllowanceOrChargePercent);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.AllowanceOrChargeQuantity);
		validator.ARequiresB(x=>x.AllowanceOrChargeQuantity2, x=>x.AllowanceOrChargeQuantity);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ReferenceNumber, x=>x.ServicePromotionAllowanceOrChargeCode, x=>x.AgencyServicePromotionAllowanceOrChangeCode);
		validator.ARequiresB(x=>x.OptionNumber, x=>x.ReferenceNumber);
		validator.Length(x => x.AllowanceOrChargeIndicator, 1);
		validator.Length(x => x.ServicePromotionAllowanceOrChargeCode, 4);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.AgencyServicePromotionAllowanceOrChangeCode, 1, 10);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.AllowanceChargePercentQualifier, 1);
		validator.Length(x => x.AllowanceOrChargePercent, 1, 6);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.AllowanceOrChargeQuantity, 1, 10);
		validator.Length(x => x.AllowanceOrChargeQuantity2, 1, 10);
		validator.Length(x => x.AllowanceOrChargeMethodOfHandlingCode, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.OptionNumber, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
