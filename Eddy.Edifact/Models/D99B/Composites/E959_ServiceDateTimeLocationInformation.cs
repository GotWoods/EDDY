using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E959")]
public class E959_ServiceDateTimeLocationInformation : EdifactComponent
{
	[Position(1)]
	public string SpecialServiceDescriptionCode { get; set; }

	[Position(2)]
	public string Time { get; set; }

	[Position(3)]
	public string Time2 { get; set; }

	[Position(4)]
	public string DateValue { get; set; }

	[Position(5)]
	public string LocationName { get; set; }

	[Position(6)]
	public string LocationNameCode { get; set; }

	[Position(7)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(8)]
	public string CharacteristicDescriptionCode { get; set; }

	[Position(9)]
	public string RelatedPlaceLocationOneIdentification { get; set; }

	[Position(10)]
	public string CountryNameCode { get; set; }

	[Position(11)]
	public string SpecialServiceDescription { get; set; }

	[Position(12)]
	public string CharacteristicDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E959_ServiceDateTimeLocationInformation>(this);
		validator.Required(x=>x.SpecialServiceDescriptionCode);
		validator.Length(x => x.SpecialServiceDescriptionCode, 1, 3);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.LocationName, 1, 256);
		validator.Length(x => x.LocationNameCode, 1, 25);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		validator.Length(x => x.RelatedPlaceLocationOneIdentification, 1, 25);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.SpecialServiceDescription, 1, 35);
		validator.Length(x => x.CharacteristicDescription, 1, 35);
		return validator.Results;
	}
}
