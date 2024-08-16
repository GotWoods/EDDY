using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("SEG")]
public class SEG_SegmentIdentification : EdifactSegment
{
	[Position(1)]
	public string SegmentTagIdentifier { get; set; }

	[Position(2)]
	public string DesignatedClassCode { get; set; }

	[Position(3)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEG_SegmentIdentification>(this);
		validator.Required(x=>x.SegmentTagIdentifier);
		validator.Length(x => x.SegmentTagIdentifier, 1, 3);
		validator.Length(x => x.DesignatedClassCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
