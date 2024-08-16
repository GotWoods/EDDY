using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("POC")]
public class POC_PurposeOfConveyanceCall : EdifactSegment
{
	[Position(1)]
	public C525_PurposeOfConveyanceCall PurposeOfConveyanceCall { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<POC_PurposeOfConveyanceCall>(this);
		validator.Required(x=>x.PurposeOfConveyanceCall);
		return validator.Results;
	}
}
