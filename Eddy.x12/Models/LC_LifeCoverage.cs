using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LC")]
public class LC_LifeCoverage : EdiX12Segment
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
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string ProductOptionCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LC_LifeCoverage>(this);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.InsuranceLineCode, 2, 3);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ProductOptionCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
