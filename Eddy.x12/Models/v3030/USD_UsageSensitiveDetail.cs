using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("USD")]
public class USD_UsageSensitiveDetail : EdiX12Segment
{
	[Position(01)]
	public string PriceRelationshipCode { get; set; }

	[Position(02)]
	public string AssignedIdentification { get; set; }

	[Position(03)]
	public decimal? AllowanceOrChargeRate { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string TermsDiscountAmount { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(11)]
	public decimal? RangeMinimum { get; set; }

	[Position(12)]
	public decimal? RangeMaximum { get; set; }

	[Position(13)]
	public string AgencyQualifierCode { get; set; }

	[Position(14)]
	public string ServiceCharacteristicsQualifier { get; set; }

	[Position(15)]
	public string ProductServiceID { get; set; }

	[Position(16)]
	public string ServiceCharacteristicsQualifier2 { get; set; }

	[Position(17)]
	public string ProductServiceID2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USD_UsageSensitiveDetail>(this);
		validator.Required(x=>x.PriceRelationshipCode);
		validator.OnlyOneOf(x=>x.AllowanceOrChargeRate, x=>x.Percent);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.AllowanceOrChargeRate, x=>x.Quantity, x=>x.Quantity2, x=>x.MonetaryAmount);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Percent, x=>x.MonetaryAmount, x=>x.TermsDiscountAmount);
		validator.ARequiresB(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOrBasisForMeasurementCode2, x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ServiceCharacteristicsQualifier, x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.ServiceCharacteristicsQualifier, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.ServiceCharacteristicsQualifier2, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.ServiceCharacteristicsQualifier2, x=>x.ProductServiceID2);
		validator.Length(x => x.PriceRelationshipCode, 1);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.AllowanceOrChargeRate, 1, 9);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.TermsDiscountAmount, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.RangeMinimum, 1, 10);
		validator.Length(x => x.RangeMaximum, 1, 10);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ServiceCharacteristicsQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ServiceCharacteristicsQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		return validator.Results;
	}
}
