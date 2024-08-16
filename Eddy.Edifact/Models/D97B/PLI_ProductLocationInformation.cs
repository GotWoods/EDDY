using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("PLI")]
public class PLI_ProductLocationInformation : EdifactSegment
{
	[Position(1)]
	public E008_GeographicDetails GeographicDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLI_ProductLocationInformation>(this);
		validator.Required(x=>x.GeographicDetails);
		return validator.Results;
	}
}
