using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("IND")]
public class IND_IndexDetails : EdifactSegment
{
	[Position(1)]
	public C545_IndexIdentification IndexIdentification { get; set; }

	[Position(2)]
	public C546_IndexValue IndexValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IND_IndexDetails>(this);
		return validator.Results;
	}
}
