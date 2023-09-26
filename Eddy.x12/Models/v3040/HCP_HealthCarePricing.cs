using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("HCP")]
public class HCP_HealthCarePricing : EdiX12Segment
{
	[Position(01)]
	public string PricingMethodology { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public decimal? Rate { get; set; }

	[Position(06)]
	public string ReferenceNumber2 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(08)]
	public string ProductServiceID { get; set; }

	[Position(09)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(10)]
	public string ProductServiceID2 { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(12)]
	public decimal? Quantity { get; set; }

	[Position(13)]
	public string RejectReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HCP_HealthCarePricing>(this);
		validator.Required(x=>x.PricingMethodology);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.PricingMethodology, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.RejectReasonCode, 2);
		return validator.Results;
	}
}
