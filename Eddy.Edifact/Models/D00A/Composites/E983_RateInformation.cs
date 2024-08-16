using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E983")]
public class E983_RateInformation : EdifactComponent
{
	[Position(1)]
	public string RateOrTariffClassDescriptionCode { get; set; }

	[Position(2)]
	public string RangeMinimumValue { get; set; }

	[Position(3)]
	public string RangeMaximumValue { get; set; }

	[Position(4)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	[Position(5)]
	public string CurrencyIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E983_RateInformation>(this);
		validator.Length(x => x.RateOrTariffClassDescriptionCode, 1, 9);
		validator.Length(x => x.RangeMinimumValue, 1, 18);
		validator.Length(x => x.RangeMaximumValue, 1, 18);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		return validator.Results;
	}
}
