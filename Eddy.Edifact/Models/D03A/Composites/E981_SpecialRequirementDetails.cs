using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("E981")]
public class E981_SpecialRequirementDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialRequirementDescription { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string TravellerReferenceIdentifier { get; set; }

	[Position(5)]
	public string CharacteristicValueDescriptionCode { get; set; }

	[Position(6)]
	public string CharacteristicValueDescriptionCode2 { get; set; }

	[Position(7)]
	public string CharacteristicValueDescriptionCode3 { get; set; }

	[Position(8)]
	public string CharacteristicValueDescriptionCode4 { get; set; }

	[Position(9)]
	public string CharacteristicValueDescriptionCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E981_SpecialRequirementDetails>(this);
		validator.Length(x => x.SpecialRequirementDescription, 1, 17);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.TravellerReferenceIdentifier, 1, 35);
		validator.Length(x => x.CharacteristicValueDescriptionCode, 1, 3);
		validator.Length(x => x.CharacteristicValueDescriptionCode2, 1, 3);
		validator.Length(x => x.CharacteristicValueDescriptionCode3, 1, 3);
		validator.Length(x => x.CharacteristicValueDescriptionCode4, 1, 3);
		validator.Length(x => x.CharacteristicValueDescriptionCode5, 1, 3);
		return validator.Results;
	}
}
