using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E976")]
public class E976_OriginatorDetails : EdifactComponent
{
	[Position(1)]
	public string CountryCoded { get; set; }

	[Position(2)]
	public string CurrencyCoded { get; set; }

	[Position(3)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E976_OriginatorDetails>(this);
		validator.Length(x => x.CountryCoded, 1, 3);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
