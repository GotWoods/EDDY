using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UGT")]
public class UGT_AntiCollisionSegmentGroupTrailer : EdifactSegment
{
	[Position(1)]
	public string AntiCollisionSegmentGroupIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UGT_AntiCollisionSegmentGroupTrailer>(this);
		validator.Required(x=>x.AntiCollisionSegmentGroupIdentification);
		validator.Length(x => x.AntiCollisionSegmentGroupIdentification, 1, 4);
		return validator.Results;
	}
}
