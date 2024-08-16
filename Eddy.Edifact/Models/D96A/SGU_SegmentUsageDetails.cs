using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("SGU")]
public class SGU_SegmentUsageDetails : EdifactSegment
{
	[Position(1)]
	public string SegmentTag { get; set; }

	[Position(2)]
	public string RequirementDesignatorCoded { get; set; }

	[Position(3)]
	public string MaximumNumberOfOccurrences { get; set; }

	[Position(4)]
	public string LevelNumber { get; set; }

	[Position(5)]
	public string SequenceNumber { get; set; }

	[Position(6)]
	public string MessageSectionCoded { get; set; }

	[Position(7)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SGU_SegmentUsageDetails>(this);
		validator.Required(x=>x.SegmentTag);
		validator.Length(x => x.SegmentTag, 1, 3);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		validator.Length(x => x.MaximumNumberOfOccurrences, 1, 7);
		validator.Length(x => x.LevelNumber, 1);
		validator.Length(x => x.SequenceNumber, 1, 6);
		validator.Length(x => x.MessageSectionCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
