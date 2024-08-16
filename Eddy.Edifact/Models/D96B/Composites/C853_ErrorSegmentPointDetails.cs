using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C853")]
public class C853_ErrorSegmentPointDetails : EdifactComponent
{
	[Position(1)]
	public string SegmentTag { get; set; }

	[Position(2)]
	public string SequenceNumber { get; set; }

	[Position(3)]
	public string SequenceNumberSourceCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C853_ErrorSegmentPointDetails>(this);
		validator.Length(x => x.SegmentTag, 1, 3);
		validator.Length(x => x.SequenceNumber, 1, 10);
		validator.Length(x => x.SequenceNumberSourceCoded, 1, 3);
		return validator.Results;
	}
}
