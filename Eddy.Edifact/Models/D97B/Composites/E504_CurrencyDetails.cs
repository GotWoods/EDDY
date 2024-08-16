using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

[Segment("E504")]
public class E504_CurrencyDetails : EdifactComponent
{
	[Position(1)]
	public string CurrencyDetailsQualifier { get; set; }

	[Position(2)]
	public string CurrencyCoded { get; set; }

	[Position(3)]
	public string CurrencyQualifier { get; set; }

	[Position(4)]
	public string CurrencyRateBase { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E504_CurrencyDetails>(this);
		validator.Required(x=>x.CurrencyDetailsQualifier);
		validator.Length(x => x.CurrencyDetailsQualifier, 1, 3);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.CurrencyQualifier, 1, 3);
		validator.Length(x => x.CurrencyRateBase, 1, 4);
		return validator.Results;
	}
}
