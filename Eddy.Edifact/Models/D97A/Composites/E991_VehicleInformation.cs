using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E991")]
public class E991_VehicleInformation : EdifactComponent
{
	[Position(1)]
	public string EquipmentSizeAndType { get; set; }

	[Position(2)]
	public string IdentityNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E991_VehicleInformation>(this);
		validator.Length(x => x.EquipmentSizeAndType, 1, 35);
		validator.Length(x => x.IdentityNumber, 1, 35);
		return validator.Results;
	}
}
