using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("UDA")]
public class UDA_UnderwritingCondition : EdiX12Segment
{
	[Position(01)]
	public string OfferBasisCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string QuantityQualifier { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public string Amount { get; set; }

	[Position(07)]
	public decimal? PercentageAsDecimal { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UDA_UnderwritingCondition>(this);
		validator.Required(x=>x.OfferBasisCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.Length(x => x.OfferBasisCode, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		return validator.Results;
	}
}
