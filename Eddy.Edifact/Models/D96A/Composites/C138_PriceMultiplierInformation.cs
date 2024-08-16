using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C138")]
public class C138_PriceMultiplierInformation : EdifactComponent
{
	[Position(1)]
	public string PriceMultiplier { get; set; }

	[Position(2)]
	public string PriceMultiplierQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C138_PriceMultiplierInformation>(this);
		validator.Required(x=>x.PriceMultiplier);
		validator.Length(x => x.PriceMultiplier, 1, 12);
		validator.Length(x => x.PriceMultiplierQualifier, 1, 3);
		return validator.Results;
	}
}
