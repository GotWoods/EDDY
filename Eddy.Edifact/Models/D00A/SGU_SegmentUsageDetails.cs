using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("SGU")]
public class SGU_SegmentUsageDetails : EdifactSegment
{
	[Position(1)]
	public string SegmentTagIdentifier { get; set; }

	[Position(2)]
	public string RequirementDesignatorCode { get; set; }

	[Position(3)]
	public string OccurrencesMaximumNumber { get; set; }

	[Position(4)]
	public string LevelNumber { get; set; }

	[Position(5)]
	public string SequencePositionIdentifier { get; set; }

	[Position(6)]
	public string MessageSectionCode { get; set; }

	[Position(7)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SGU_SegmentUsageDetails>(this);
		validator.Required(x=>x.SegmentTagIdentifier);
		validator.Length(x => x.SegmentTagIdentifier, 1, 3);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		validator.Length(x => x.OccurrencesMaximumNumber, 1, 7);
		validator.Length(x => x.LevelNumber, 1, 3);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.MessageSectionCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
