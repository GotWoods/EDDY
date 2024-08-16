using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("POR")]
public class POR_LocationAndOrRelatedTimeInformation : EdifactSegment
{
	[Position(1)]
	public E517_LocationIdentification LocationIdentification { get; set; }

	[Position(2)]
	public E362_RelatedTimeInformation RelatedTimeInformation { get; set; }

	[Position(3)]
	public E992_Position Position { get; set; }

	[Position(4)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(5)]
	public string SequencePositionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<POR_LocationAndOrRelatedTimeInformation>(this);
		validator.Required(x=>x.LocationIdentification);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		return validator.Results;
	}
}
