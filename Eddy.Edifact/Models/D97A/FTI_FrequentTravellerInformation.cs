using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("FTI")]
public class FTI_FrequentTravellerInformation : EdifactSegment
{
	[Position(1)]
	public E970_FrequentTravellerIdentification FrequentTravellerIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FTI_FrequentTravellerInformation>(this);
		validator.Required(x=>x.FrequentTravellerIdentification);
		return validator.Results;
	}
}
