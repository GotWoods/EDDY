using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("SFI")]
public class SFI_SafetyInformation : EdifactSegment
{
	[Position(1)]
	public string HierarchicalIdNumber { get; set; }

	[Position(2)]
	public C814_SafetySection SafetySection { get; set; }

	[Position(3)]
	public C815_AdditionalSafetyInformation AdditionalSafetyInformation { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SFI_SafetyInformation>(this);
		validator.Required(x=>x.HierarchicalIdNumber);
		validator.Length(x => x.HierarchicalIdNumber, 1, 35);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
