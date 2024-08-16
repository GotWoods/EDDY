using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("ODI")]
public class ODI_OriginAndDestinationDetails : EdifactSegment
{
	[Position(1)]
	public string LocationNameCode { get; set; }

	[Position(2)]
	public string SequencePositionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ODI_OriginAndDestinationDetails>(this);
		validator.Length(x => x.LocationNameCode, 1, 35);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		return validator.Results;
	}
}
