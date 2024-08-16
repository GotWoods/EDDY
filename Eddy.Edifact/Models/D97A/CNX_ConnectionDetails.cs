using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("CNX")]
public class CNX_ConnectionDetails : EdifactSegment
{
	[Position(1)]
	public E999_ConnectionDetails ConnectionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CNX_ConnectionDetails>(this);
		return validator.Results;
	}
}
