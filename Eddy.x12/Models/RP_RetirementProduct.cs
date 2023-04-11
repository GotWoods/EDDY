using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RP")]
public class RP_RetirementProduct : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceTypeCode { get; set; }

	[Position(02)]
	public string InsuranceLineCode { get; set; }

	[Position(03)]
	public string MaintenanceReasonCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string ParticipantStatusCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string SpecialProcessingType { get; set; }

	[Position(08)]
	public string Authority { get; set; }

	[Position(09)]
	public string PlanCoverageDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RP_RetirementProduct>(this);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		validator.Length(x => x.InsuranceLineCode, 2, 3);
		validator.Length(x => x.MaintenanceReasonCode, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ParticipantStatusCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.SpecialProcessingType, 1, 6);
		validator.Length(x => x.Authority, 1, 20);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		return validator.Results;
	}
}
