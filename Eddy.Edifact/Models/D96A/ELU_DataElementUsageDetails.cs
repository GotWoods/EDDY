using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ELU")]
public class ELU_DataElementUsageDetails : EdifactSegment
{
	[Position(1)]
	public string DataElementTag { get; set; }

	[Position(2)]
	public string RequirementDesignatorCoded { get; set; }

	[Position(3)]
	public string SequenceNumber { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELU_DataElementUsageDetails>(this);
		validator.Required(x=>x.DataElementTag);
		validator.Length(x => x.DataElementTag, 1, 4);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		validator.Length(x => x.SequenceNumber, 1, 6);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
