using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("TMD")]
public class TMD_TransportMovementDetails : EdifactSegment
{
	[Position(1)]
	public C219_MovementType MovementType { get; set; }

	[Position(2)]
	public string EquipmentPlan { get; set; }

	[Position(3)]
	public string HaulageArrangementsCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TMD_TransportMovementDetails>(this);
		validator.Length(x => x.EquipmentPlan, 1, 26);
		validator.Length(x => x.HaulageArrangementsCoded, 1, 3);
		return validator.Results;
	}
}
