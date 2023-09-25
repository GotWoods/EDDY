using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("USD")]
public class USD_UsageSensitiveDetail : EdiX12Segment
{
	[Position(01)]
	public string RelationshipCode { get; set; }

	[Position(02)]
	public string AssignedIdentification { get; set; }

	[Position(03)]
	public decimal? Rate { get; set; }

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
	public string Amount { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(11)]
	public decimal? RangeMinimum { get; set; }

	[Position(12)]
	public decimal? RangeMaximum { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USD_UsageSensitiveDetail>(this);
		validator.Required(x=>x.RelationshipCode);
		validator.OnlyOneOf(x=>x.Rate, x=>x.Percent);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Rate, x=>x.Quantity, x=>x.Quantity2, x=>x.MonetaryAmount);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Percent, x=>x.MonetaryAmount, x=>x.Amount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOrBasisForMeasurementCode2, x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.ARequiresB(x=>x.RangeMinimum, x=>x.UnitOrBasisForMeasurementCode2);
		validator.ARequiresB(x=>x.RangeMaximum, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.RelationshipCode, 1);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		return validator.Results;
	}
}
