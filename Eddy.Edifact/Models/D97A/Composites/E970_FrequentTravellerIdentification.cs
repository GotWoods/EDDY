using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E970")]
public class E970_FrequentTravellerIdentification : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string FrequentTravellerIdentification { get; set; }

	[Position(3)]
	public string TravellerReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E970_FrequentTravellerIdentification>(this);
		validator.Required(x=>x.PartyName);
		validator.Required(x=>x.FrequentTravellerIdentification);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.FrequentTravellerIdentification, 1, 25);
		validator.Length(x => x.TravellerReferenceNumber, 1, 35);
		return validator.Results;
	}
}
