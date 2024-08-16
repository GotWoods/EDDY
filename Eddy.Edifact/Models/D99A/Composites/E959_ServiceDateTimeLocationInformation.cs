using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E959")]
public class E959_ServiceDateTimeLocationInformation : EdifactComponent
{
	[Position(1)]
	public string SpecialServicesCoded { get; set; }

	[Position(2)]
	public string Time { get; set; }

	[Position(3)]
	public string Time2 { get; set; }

	[Position(4)]
	public string Date { get; set; }

	[Position(5)]
	public string PlaceLocation { get; set; }

	[Position(6)]
	public string PlaceLocationIdentification { get; set; }

	[Position(7)]
	public string PlaceLocationQualifier { get; set; }

	[Position(8)]
	public string CharacteristicIdentification { get; set; }

	[Position(9)]
	public string RelatedPlaceLocationOneIdentification { get; set; }

	[Position(10)]
	public string CountryCoded { get; set; }

	[Position(11)]
	public string SpecialService { get; set; }

	[Position(12)]
	public string Characteristic { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E959_ServiceDateTimeLocationInformation>(this);
		validator.Required(x=>x.SpecialServicesCoded);
		validator.Length(x => x.SpecialServicesCoded, 1, 3);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.PlaceLocation, 1, 70);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PlaceLocationQualifier, 1, 3);
		validator.Length(x => x.CharacteristicIdentification, 1, 17);
		validator.Length(x => x.RelatedPlaceLocationOneIdentification, 1, 25);
		validator.Length(x => x.CountryCoded, 1, 3);
		validator.Length(x => x.SpecialService, 1, 35);
		validator.Length(x => x.Characteristic, 1, 35);
		return validator.Results;
	}
}
