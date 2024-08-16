using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E968")]
public class E968_DocumentInformation : EdifactComponent
{
	[Position(1)]
	public string DocumentMessageNameCoded { get; set; }

	[Position(2)]
	public string DocumentMessageNumber { get; set; }

	[Position(3)]
	public string CharacteristicValueCoded { get; set; }

	[Position(4)]
	public string PlaceLocationIdentification { get; set; }

	[Position(5)]
	public string CountryCoded { get; set; }

	[Position(6)]
	public string CountryCoded2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E968_DocumentInformation>(this);
		validator.Required(x=>x.DocumentMessageNameCoded);
		validator.Required(x=>x.DocumentMessageNumber);
		validator.Length(x => x.DocumentMessageNameCoded, 1, 3);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.CharacteristicValueCoded, 1, 3);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.CountryCoded, 1, 3);
		validator.Length(x => x.CountryCoded2, 1, 3);
		return validator.Results;
	}
}
