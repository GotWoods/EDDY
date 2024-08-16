using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("TMD")]
public class TMD_TransportMovementDetails : EdifactSegment
{
	[Position(1)]
	public C219_MovementType MovementType { get; set; }

	[Position(2)]
	public string EquipmentPlanDescription { get; set; }

	[Position(3)]
	public string HaulageArrangementsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TMD_TransportMovementDetails>(this);
		validator.Length(x => x.EquipmentPlanDescription, 1, 26);
		validator.Length(x => x.HaulageArrangementsCode, 1, 3);
		return validator.Results;
	}
}
