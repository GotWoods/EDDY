using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("TIF")]
public class TIF_TravellerInformation : EdifactSegment
{
	[Position(1)]
	public E985_TravellerSurnameAndRelatedInformation TravellerSurnameAndRelatedInformation { get; set; }

	[Position(2)]
	public E986_TravellerDetails TravellerDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIF_TravellerInformation>(this);
		validator.Required(x=>x.TravellerSurnameAndRelatedInformation);
		return validator.Results;
	}
}
