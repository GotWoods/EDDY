using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040.Composites;

namespace Eddy.x12.Models.v4040;

[Segment("CTB")]
public class CTB_RestrictionsConditions : EdiX12Segment
{
	[Position(01)]
	public string RestrictionsConditionsQualifier { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string QuantityQualifier { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string AmountQualifierCode { get; set; }

	[Position(06)]
	public string Amount { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTB_RestrictionsConditions>(this);
		validator.Required(x=>x.RestrictionsConditionsQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.Amount);
		validator.Length(x => x.RestrictionsConditionsQualifier, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
