using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G26")]
public class G26_PricingConditions : EdiX12Segment
{
	[Position(01)]
	public string PriceConditionCode { get; set; }

	[Position(02)]
	public string DateQualifier { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string QuantityBasisCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G26_PricingConditions>(this);
		validator.Required(x=>x.PriceConditionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateQualifier, x=>x.Date);
		validator.Length(x => x.PriceConditionCode, 2);
		validator.Length(x => x.DateQualifier, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.QuantityBasisCode, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
