using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E986")]
public class E986_TravellerDetails : EdifactComponent
{
	[Position(1)]
	public string GivenName { get; set; }

	[Position(2)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(3)]
	public string TravellerReferenceIdentifier { get; set; }

	[Position(4)]
	public string GivenNameTitleDescription { get; set; }

	[Position(5)]
	public string TravellerAccompaniedByInfantIndicatorCode { get; set; }

	[Position(6)]
	public string LanguageNameCode { get; set; }

	[Position(7)]
	public string GenderCode { get; set; }

	[Position(8)]
	public string AgeValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E986_TravellerDetails>(this);
		validator.Length(x => x.GivenName, 1, 70);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.TravellerReferenceIdentifier, 1, 35);
		validator.Length(x => x.GivenNameTitleDescription, 1, 9);
		validator.Length(x => x.TravellerAccompaniedByInfantIndicatorCode, 1);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.GenderCode, 1, 3);
		validator.Length(x => x.AgeValue, 1, 3);
		return validator.Results;
	}
}
