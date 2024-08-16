using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("SAL")]
public class SAL_RemunerationTypeIdentification : EdifactSegment
{
	[Position(1)]
	public C049_RemunerationTypeIdentification RemunerationTypeIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SAL_RemunerationTypeIdentification>(this);
		return validator.Results;
	}
}
