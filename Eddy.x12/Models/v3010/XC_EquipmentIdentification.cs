using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("XC")]
public class XC_EquipmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(04)]
	public string CommodityCode { get; set; }

	[Position(05)]
	public string TypeOfConsistCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XC_EquipmentIdentification>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.LoadEmptyStatusCode);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.TypeOfConsistCode, 1);
		return validator.Results;
	}
}
