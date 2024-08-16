using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("SEG")]
public class SEG_SegmentIdentification : EdifactSegment
{
	[Position(1)]
	public string SegmentTag { get; set; }

	[Position(2)]
	public string ClassDesignatorCoded { get; set; }

	[Position(3)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEG_SegmentIdentification>(this);
		validator.Required(x=>x.SegmentTag);
		validator.Length(x => x.SegmentTag, 1, 3);
		validator.Length(x => x.ClassDesignatorCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
