using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("EQD")]
public class EQD_EquipmentDetails : EdifactSegment
{
	[Position(1)]
	public string EquipmentQualifier { get; set; }

	[Position(2)]
	public C237_EquipmentIdentification EquipmentIdentification { get; set; }

	[Position(3)]
	public C224_EquipmentSizeAndType EquipmentSizeAndType { get; set; }

	[Position(4)]
	public string EquipmentSupplierCoded { get; set; }

	[Position(5)]
	public string EquipmentStatusCoded { get; set; }

	[Position(6)]
	public string FullEmptyIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQD_EquipmentDetails>(this);
		validator.Required(x=>x.EquipmentQualifier);
		validator.Length(x => x.EquipmentQualifier, 1, 3);
		validator.Length(x => x.EquipmentSupplierCoded, 1, 3);
		validator.Length(x => x.EquipmentStatusCoded, 1, 3);
		validator.Length(x => x.FullEmptyIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
