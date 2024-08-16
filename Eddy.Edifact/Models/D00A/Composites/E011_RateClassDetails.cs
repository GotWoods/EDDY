using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E011")]
public class E011_RateClassDetails : EdifactComponent
{
	[Position(1)]
	public string RateOrTariffClassDescriptionCode { get; set; }

	[Position(2)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E011_RateClassDetails>(this);
		validator.Required(x=>x.RateOrTariffClassDescriptionCode);
		validator.Length(x => x.RateOrTariffClassDescriptionCode, 1, 9);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		return validator.Results;
	}
}
