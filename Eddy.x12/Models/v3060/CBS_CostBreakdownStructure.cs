using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("CBS")]
public class CBS_CostBreakdownStructure : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CBS_CostBreakdownStructure>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
