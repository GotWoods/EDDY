using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("HD")]
public class HD_HealthCoverage : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceTypeCode { get; set; }

	[Position(02)]
	public string MaintenanceReasonCode { get; set; }

	[Position(03)]
	public string InsuranceLineCode { get; set; }

	[Position(04)]
	public string PlanCoverageDescription { get; set; }

	[Position(05)]
	public string CoverageLevelCode { get; set; }

	[Position(06)]
	public int? Count { get; set; }

	[Position(07)]
	public int? Count2 { get; set; }

	[Position(08)]
	public string UnderwritingDecisionCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string DrugHouseCode { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HD_HealthCoverage>(this);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.InsuranceLineCode, 2, 3);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.CoverageLevelCode, 3);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.Count2, 1, 9);
		validator.Length(x => x.UnderwritingDecisionCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DrugHouseCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
