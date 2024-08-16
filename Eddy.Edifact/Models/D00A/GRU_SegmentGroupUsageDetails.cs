using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("GRU")]
public class GRU_SegmentGroupUsageDetails : EdifactSegment
{
	[Position(1)]
	public string GroupIdentifier { get; set; }

	[Position(2)]
	public string RequirementDesignatorCode { get; set; }

	[Position(3)]
	public string OccurrencesMaximumNumber { get; set; }

	[Position(4)]
	public string MaintenanceOperationCode { get; set; }

	[Position(5)]
	public string SequencePositionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GRU_SegmentGroupUsageDetails>(this);
		validator.Required(x=>x.GroupIdentifier);
		validator.Length(x => x.GroupIdentifier, 1, 4);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		validator.Length(x => x.OccurrencesMaximumNumber, 1, 7);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		return validator.Results;
	}
}
