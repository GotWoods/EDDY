using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("IC")]
public class IC_IntermodalChassisEquipment : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public int? TareWeight { get; set; }

	[Position(04)]
	public string TareQualifierCode { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public int? EquipmentLength { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(08)]
	public string ChassisType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IC_IntermodalChassisEquipment>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TareWeight, x=>x.TareQualifierCode);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.TareWeight, 3, 8);
		validator.Length(x => x.TareQualifierCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.ChassisType, 2);
		return validator.Results;
	}
}
