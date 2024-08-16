using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06B.Composites;

namespace Eddy.Edifact.Models.D06B;

[Segment("EQD")]
public class EQD_EquipmentDetails : EdifactSegment
{
	[Position(1)]
	public string EquipmentTypeCodeQualifier { get; set; }

	[Position(2)]
	public C237_EquipmentIdentification EquipmentIdentification { get; set; }

	[Position(3)]
	public C224_EquipmentSizeAndType EquipmentSizeAndType { get; set; }

	[Position(4)]
	public string EquipmentSupplierCode { get; set; }

	[Position(5)]
	public string EquipmentStatusCode { get; set; }

	[Position(6)]
	public string FullOrEmptyIndicatorCode { get; set; }

	[Position(7)]
	public string MarkingInstructionsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQD_EquipmentDetails>(this);
		validator.Required(x=>x.EquipmentTypeCodeQualifier);
		validator.Length(x => x.EquipmentTypeCodeQualifier, 1, 3);
		validator.Length(x => x.EquipmentSupplierCode, 1, 3);
		validator.Length(x => x.EquipmentStatusCode, 1, 3);
		validator.Length(x => x.FullOrEmptyIndicatorCode, 1, 3);
		validator.Length(x => x.MarkingInstructionsCode, 1, 3);
		return validator.Results;
	}
}
