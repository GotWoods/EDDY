using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("B12")]
public class B12_BeginningSegmentForConsolidationOfGoodsInContainer : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string EquipmentTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B12_BeginningSegmentForConsolidationOfGoodsInContainer>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.EquipmentTypeCode);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.EquipmentTypeCode, 4);
		return validator.Results;
	}
}
