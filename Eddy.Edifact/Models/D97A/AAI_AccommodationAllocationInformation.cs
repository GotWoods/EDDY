using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("AAI")]
public class AAI_AccommodationAllocationInformation : EdifactSegment
{
	[Position(1)]
	public E997_AccommodationAllocationInformation AccommodationAllocationInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AAI_AccommodationAllocationInformation>(this);
		validator.Required(x=>x.AccommodationAllocationInformation);
		return validator.Results;
	}
}
