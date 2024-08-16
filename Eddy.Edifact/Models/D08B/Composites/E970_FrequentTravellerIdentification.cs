using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E970")]
public class E970_FrequentTravellerIdentification : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string FrequentTravellerIdentifier { get; set; }

	[Position(3)]
	public string TravellerReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E970_FrequentTravellerIdentification>(this);
		validator.Required(x=>x.PartyName);
		validator.Required(x=>x.FrequentTravellerIdentifier);
		validator.Length(x => x.PartyName, 1, 70);
		validator.Length(x => x.FrequentTravellerIdentifier, 1, 25);
		validator.Length(x => x.TravellerReferenceIdentifier, 1, 35);
		return validator.Results;
	}
}
