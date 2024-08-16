using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("DIS")]
public class DIS_DiscountInformation : EdifactSegment
{
	[Position(1)]
	public E998_DiscountInformation DiscountInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DIS_DiscountInformation>(this);
		validator.Required(x=>x.DiscountInformation);
		return validator.Results;
	}
}
