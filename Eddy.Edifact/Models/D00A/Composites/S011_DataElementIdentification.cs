using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S011")]
public class S011_DataElementIdentification : EdifactComponent
{
	[Position(1)]
	public string ErroneousDataElementPositionInSegment { get; set; }

	[Position(2)]
	public string ErroneousComponentDataElementPosition { get; set; }

	[Position(3)]
	public string ErroneousDataElementOccurrence { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S011_DataElementIdentification>(this);
		validator.Required(x=>x.ErroneousDataElementPositionInSegment);
		validator.Length(x => x.ErroneousDataElementPositionInSegment, 1, 3);
		validator.Length(x => x.ErroneousComponentDataElementPosition, 1, 3);
		validator.Length(x => x.ErroneousDataElementOccurrence, 1, 6);
		return validator.Results;
	}
}
