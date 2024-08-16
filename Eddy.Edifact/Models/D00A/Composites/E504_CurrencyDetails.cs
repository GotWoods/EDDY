using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E504")]
public class E504_CurrencyDetails : EdifactComponent
{
	[Position(1)]
	public string CurrencyUsageCodeQualifier { get; set; }

	[Position(2)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(3)]
	public string CurrencyTypeCodeQualifier { get; set; }

	[Position(4)]
	public string CurrencyRateValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E504_CurrencyDetails>(this);
		validator.Required(x=>x.CurrencyUsageCodeQualifier);
		validator.Length(x => x.CurrencyUsageCodeQualifier, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.CurrencyTypeCodeQualifier, 1, 3);
		validator.Length(x => x.CurrencyRateValue, 1, 4);
		return validator.Results;
	}
}
