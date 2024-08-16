using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ERP")]
public class ERP_ErrorPointDetails : EdifactSegment
{
	[Position(1)]
	public C701_ErrorPointDetails ErrorPointDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERP_ErrorPointDetails>(this);
		validator.Required(x=>x.ErrorPointDetails);
		return validator.Results;
	}
}
