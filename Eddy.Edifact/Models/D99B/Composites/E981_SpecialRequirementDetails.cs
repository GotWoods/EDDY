using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E981")]
public class E981_SpecialRequirementDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialRequirementDetail { get; set; }

	[Position(2)]
	public string MeasurementUnitCode { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string TravellerReferenceNumber { get; set; }

	[Position(5)]
	public string CharacteristicValueCoded { get; set; }

	[Position(6)]
	public string CharacteristicValueCoded2 { get; set; }

	[Position(7)]
	public string CharacteristicValueCoded3 { get; set; }

	[Position(8)]
	public string CharacteristicValueCoded4 { get; set; }

	[Position(9)]
	public string CharacteristicValueCoded5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E981_SpecialRequirementDetails>(this);
		validator.Length(x => x.SpecialRequirementDetail, 1, 17);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.TravellerReferenceNumber, 1, 35);
		validator.Length(x => x.CharacteristicValueCoded, 1, 3);
		validator.Length(x => x.CharacteristicValueCoded2, 1, 3);
		validator.Length(x => x.CharacteristicValueCoded3, 1, 3);
		validator.Length(x => x.CharacteristicValueCoded4, 1, 3);
		validator.Length(x => x.CharacteristicValueCoded5, 1, 3);
		return validator.Results;
	}
}
