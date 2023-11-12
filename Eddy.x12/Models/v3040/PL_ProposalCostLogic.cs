using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PL")]
public class PL_ProposalCostLogic : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string CalculationOperationCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public int? Count { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PL_ProposalCostLogic>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.Name);
		validator.Required(x=>x.CalculationOperationCode);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.CalculationOperationCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Count, 1, 9);
		return validator.Results;
	}
}
