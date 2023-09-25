using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("B12")]
public class B12_BeginningSegmentForConsolidationOfGoodsInContainer : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string EquipmentType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B12_BeginningSegmentForConsolidationOfGoodsInContainer>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.EquipmentType);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.EquipmentType, 4);
		return validator.Results;
	}
}
