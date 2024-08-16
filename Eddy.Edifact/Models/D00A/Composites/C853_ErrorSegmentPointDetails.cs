using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C853")]
public class C853_ErrorSegmentPointDetails : EdifactComponent
{
	[Position(1)]
	public string SegmentTagIdentifier { get; set; }

	[Position(2)]
	public string SequencePositionIdentifier { get; set; }

	[Position(3)]
	public string SequenceIdentifierSourceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C853_ErrorSegmentPointDetails>(this);
		validator.Length(x => x.SegmentTagIdentifier, 1, 3);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.SequenceIdentifierSourceCode, 1, 3);
		return validator.Results;
	}
}
