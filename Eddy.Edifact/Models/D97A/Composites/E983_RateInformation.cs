using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E983")]
public class E983_RateInformation : EdifactComponent
{
	[Position(1)]
	public string RateTariffClassIdentification { get; set; }

	[Position(2)]
	public string RangeMinimum { get; set; }

	[Position(3)]
	public string RangeMaximum { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E983_RateInformation>(this);
		validator.Length(x => x.RateTariffClassIdentification, 1, 9);
		validator.Length(x => x.RangeMinimum, 1, 18);
		validator.Length(x => x.RangeMaximum, 1, 18);
		return validator.Results;
	}
}
