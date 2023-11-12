using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("ITA")]
public class ITA_AllowanceChargeOrService : EdiX12Segment
{
	[Position(01)]
	public string AllowanceOrChargeIndicator { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string SpecialServicesCode { get; set; }

	[Position(04)]
	public string AllowanceOrChargeMethodOfHandlingCode { get; set; }

	[Position(05)]
	public string AllowanceOrChargeNumber { get; set; }

	[Position(06)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(07)]
	public string AllowanceOrChargeTotalAmount { get; set; }

	[Position(08)]
	public string AllowanceChargePercentQualifier { get; set; }

	[Position(09)]
	public decimal? AllowanceOrChargePercent { get; set; }

	[Position(10)]
	public decimal? AllowanceOrChargeQuantity { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(12)]
	public decimal? Quantity { get; set; }

	[Position(13)]
	public string Description { get; set; }

	[Position(14)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(15)]
	public string SourceSubqualifier { get; set; }

	[Position(16)]
	public string PriceRelationshipCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITA_AllowanceChargeOrService>(this);
		validator.Required(x=>x.AllowanceOrChargeIndicator);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.AgencyQualifierCode, x=>x.SpecialServicesCode, x=>x.Description, x=>x.SpecialChargeOrAllowanceCode);
		validator.Required(x=>x.AllowanceOrChargeMethodOfHandlingCode);
		validator.ARequiresB(x=>x.AllowanceChargePercentQualifier, x=>x.AllowanceOrChargePercent);
		validator.ARequiresB(x=>x.AllowanceOrChargeQuantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.Length(x => x.AllowanceOrChargeIndicator, 1);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.AllowanceOrChargeMethodOfHandlingCode, 2);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 9);
		validator.Length(x => x.AllowanceOrChargeTotalAmount, 1, 9);
		validator.Length(x => x.AllowanceChargePercentQualifier, 1);
		validator.Length(x => x.AllowanceOrChargePercent, 1, 6);
		validator.Length(x => x.AllowanceOrChargeQuantity, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.PriceRelationshipCode, 1);
		return validator.Results;
	}
}
