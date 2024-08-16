using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02A.Composites;

[Segment("C504")]
public class C504_CurrencyDetails : EdifactComponent
{
	[Position(1)]
	public string CurrencyUsageCodeQualifier { get; set; }

	[Position(2)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(3)]
	public string CurrencyTypeCodeQualifier { get; set; }

	[Position(4)]
	public string CurrencyRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C504_CurrencyDetails>(this);
		validator.Required(x=>x.CurrencyUsageCodeQualifier);
		validator.Length(x => x.CurrencyUsageCodeQualifier, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.CurrencyTypeCodeQualifier, 1, 3);
		validator.Length(x => x.CurrencyRate, 1, 4);
		return validator.Results;
	}
}
