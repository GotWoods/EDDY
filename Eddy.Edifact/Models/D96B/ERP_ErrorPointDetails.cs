using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("ERP")]
public class ERP_ErrorPointDetails : EdifactSegment
{
	[Position(1)]
	public C701_ErrorPointDetails ErrorPointDetails { get; set; }

	[Position(2)]
	public C853_ErrorSegmentPointDetails ErrorSegmentPointDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERP_ErrorPointDetails>(this);
		return validator.Results;
	}
}
