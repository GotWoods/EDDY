using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UCS")]
public class UCS_SegmentErrorIndication : EdifactSegment
{
	[Position(1)]
	public string SegmentPositionInMessageBody { get; set; }

	[Position(2)]
	public string SyntaxErrorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCS_SegmentErrorIndication>(this);
		validator.Required(x=>x.SegmentPositionInMessageBody);
		validator.Length(x => x.SegmentPositionInMessageBody, 1, 6);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		return validator.Results;
	}
}
