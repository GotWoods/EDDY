using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C138")]
public class C138_PriceMultiplierInformation : EdifactComponent
{
	[Position(1)]
	public string PriceMultiplierRate { get; set; }

	[Position(2)]
	public string PriceMultiplierTypeCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C138_PriceMultiplierInformation>(this);
		validator.Required(x=>x.PriceMultiplierRate);
		validator.Length(x => x.PriceMultiplierRate, 1, 12);
		validator.Length(x => x.PriceMultiplierTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
