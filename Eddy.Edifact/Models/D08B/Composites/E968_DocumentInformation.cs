using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E968")]
public class E968_DocumentInformation : EdifactComponent
{
	[Position(1)]
	public string DocumentNameCode { get; set; }

	[Position(2)]
	public string DocumentIdentifier { get; set; }

	[Position(3)]
	public string CharacteristicValueDescriptionCode { get; set; }

	[Position(4)]
	public string LocationIdentifier { get; set; }

	[Position(5)]
	public string CountryIdentifier { get; set; }

	[Position(6)]
	public string CountryIdentifier2 { get; set; }

	[Position(7)]
	public string CityName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E968_DocumentInformation>(this);
		validator.Required(x=>x.DocumentNameCode);
		validator.Length(x => x.DocumentNameCode, 1, 3);
		validator.Length(x => x.DocumentIdentifier, 1, 70);
		validator.Length(x => x.CharacteristicValueDescriptionCode, 1, 3);
		validator.Length(x => x.LocationIdentifier, 1, 35);
		validator.Length(x => x.CountryIdentifier, 1, 3);
		validator.Length(x => x.CountryIdentifier2, 1, 3);
		validator.Length(x => x.CityName, 1, 35);
		return validator.Results;
	}
}
