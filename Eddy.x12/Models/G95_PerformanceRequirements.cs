using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G95")]
public class G95_PerformanceRequirements : EdiX12Segment
{
	[Position(01)]
	public string PromotionConditionQualifier { get; set; }

	[Position(02)]
	public string PromotionConditionCode { get; set; }

	[Position(03)]
	public int? AssignedNumber { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G95_PerformanceRequirements>(this);
		validator.Required(x=>x.PromotionConditionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.PromotionConditionQualifier, 2);
		validator.Length(x => x.PromotionConditionCode, 2);
		validator.Length(x => x.AssignedNumber, 1, 9);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
