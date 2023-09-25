using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CBS")]
public class CBS_CostBreakdownStructure : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CBS_CostBreakdownStructure>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
