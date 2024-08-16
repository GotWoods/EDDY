using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E986")]
public class E986_TravellerDetails : EdifactComponent
{
	[Position(1)]
	public string GivenName { get; set; }

	[Position(2)]
	public string PartyQualifier { get; set; }

	[Position(3)]
	public string TravellerReferenceNumber { get; set; }

	[Position(4)]
	public string Title { get; set; }

	[Position(5)]
	public string TravellerAccompaniedByInfantIndicator { get; set; }

	[Position(6)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E986_TravellerDetails>(this);
		validator.Length(x => x.GivenName, 1, 70);
		validator.Length(x => x.PartyQualifier, 1, 3);
		validator.Length(x => x.TravellerReferenceNumber, 1, 35);
		validator.Length(x => x.Title, 1, 9);
		validator.Length(x => x.TravellerAccompaniedByInfantIndicator, 1);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
