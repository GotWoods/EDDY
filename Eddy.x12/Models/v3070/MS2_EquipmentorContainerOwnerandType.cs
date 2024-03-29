using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("MS2")]
public class MS2_EquipmentOrContainerOwnerAndType : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(04)]
	public int? EquipmentNumberCheckDigit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS2_EquipmentOrContainerOwnerAndType>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardCarrierAlphaCode, x=>x.EquipmentNumber);
		validator.ARequiresB(x=>x.EquipmentNumberCheckDigit, x=>x.EquipmentNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		return validator.Results;
	}
}
