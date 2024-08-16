using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E959")]
public class E959_AdditionalServiceDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialServiceDescriptionCode { get; set; }

	[Position(2)]
	public string Time { get; set; }

	[Position(3)]
	public string Time2 { get; set; }

	[Position(4)]
	public string Date { get; set; }

	[Position(5)]
	public string LocationName { get; set; }

	[Position(6)]
	public string LocationNameCode { get; set; }

	[Position(7)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(8)]
	public string CharacteristicDescriptionCode { get; set; }

	[Position(9)]
	public string FirstRelatedLocationNameCode { get; set; }

	[Position(10)]
	public string CountryNameCode { get; set; }

	[Position(11)]
	public string SpecialServiceDescription { get; set; }

	[Position(12)]
	public string CharacteristicDescription { get; set; }

	[Position(13)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(14)]
	public string SecondRelatedLocationNameCode { get; set; }

	[Position(15)]
	public string LanguageNameCode { get; set; }

	[Position(16)]
	public string FrequencyRate { get; set; }

	[Position(17)]
	public string MeasurementUnitCode { get; set; }

	[Position(18)]
	public string Quantity { get; set; }

	[Position(19)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E959_AdditionalServiceDetails>(this);
		validator.Required(x=>x.SpecialServiceDescriptionCode);
		validator.Length(x => x.SpecialServiceDescriptionCode, 1, 3);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.LocationName, 1, 256);
		validator.Length(x => x.LocationNameCode, 1, 35);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		validator.Length(x => x.FirstRelatedLocationNameCode, 1, 25);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.SpecialServiceDescription, 1, 35);
		validator.Length(x => x.CharacteristicDescription, 1, 35);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.SecondRelatedLocationNameCode, 1, 25);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.FrequencyRate, 1, 9);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.PartyName, 1, 35);
		return validator.Results;
	}
}
