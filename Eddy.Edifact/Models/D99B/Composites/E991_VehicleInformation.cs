using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E991")]
public class E991_VehicleInformation : EdifactComponent
{
	[Position(1)]
	public string EquipmentSizeAndTypeDescription { get; set; }

	[Position(2)]
	public string ObjectIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E991_VehicleInformation>(this);
		validator.Length(x => x.EquipmentSizeAndTypeDescription, 1, 35);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		return validator.Results;
	}
}
