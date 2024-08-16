using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("VEH")]
public class VEH_Vehicle : EdifactSegment
{
	[Position(1)]
	public string EquipmentTypeCodeQualifier { get; set; }

	[Position(2)]
	public E991_VehicleInformation VehicleInformation { get; set; }

	[Position(3)]
	public E211_Dimensions Dimensions { get; set; }

	[Position(4)]
	public string MeasurementValue { get; set; }

	[Position(5)]
	public E992_Position Position { get; set; }

	[Position(6)]
	public string TravellerReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VEH_Vehicle>(this);
		validator.Length(x => x.EquipmentTypeCodeQualifier, 1, 3);
		validator.Length(x => x.MeasurementValue, 1, 18);
		validator.Length(x => x.TravellerReferenceIdentifier, 1, 35);
		return validator.Results;
	}
}
