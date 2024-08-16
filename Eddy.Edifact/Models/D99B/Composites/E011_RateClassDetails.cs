using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E011")]
public class E011_RateClassDetails : EdifactComponent
{
	[Position(1)]
	public string RateTariffClassIdentification { get; set; }

	[Position(2)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E011_RateClassDetails>(this);
		validator.Required(x=>x.RateTariffClassIdentification);
		validator.Length(x => x.RateTariffClassIdentification, 1, 9);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		return validator.Results;
	}
}
