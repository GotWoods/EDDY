using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("CIC")]
public class CIC_CarInformationControl : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string CarTypeCode { get; set; }

	[Position(04)]
	public string EquipmentNumber2 { get; set; }

	[Position(05)]
	public string MechanicalCarCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CIC_CarInformationControl>(this);
		validator.OnlyOneOf(x=>x.CarTypeCode, x=>x.MechanicalCarCode);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.EquipmentNumber2, 1, 15);
		validator.Length(x => x.MechanicalCarCode, 4);
		return validator.Results;
	}
}
