using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("CMN")]
public class CMN_CommissionInformation : EdifactSegment
{
	[Position(1)]
	public E002_CommissionDetails CommissionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CMN_CommissionInformation>(this);
		validator.Required(x=>x.CommissionDetails);
		return validator.Results;
	}
}
