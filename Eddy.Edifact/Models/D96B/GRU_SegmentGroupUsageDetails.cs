using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("GRU")]
public class GRU_SegmentGroupUsageDetails : EdifactSegment
{
	[Position(1)]
	public string GroupIdentification { get; set; }

	[Position(2)]
	public string RequirementDesignatorCoded { get; set; }

	[Position(3)]
	public string MaximumNumberOfOccurrences { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	[Position(5)]
	public string SequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GRU_SegmentGroupUsageDetails>(this);
		validator.Required(x=>x.GroupIdentification);
		validator.Length(x => x.GroupIdentification, 1, 4);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		validator.Length(x => x.MaximumNumberOfOccurrences, 1, 7);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		validator.Length(x => x.SequenceNumber, 1, 10);
		return validator.Results;
	}
}
