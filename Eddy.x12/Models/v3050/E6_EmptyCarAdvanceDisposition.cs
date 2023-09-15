using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("E6")]
public class E6_AdvanceCarDisposition : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string CityName { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string IntermediateSwitchCarrier { get; set; }

	[Position(07)]
	public string CommodityCode { get; set; }

	[Position(08)]
	public string CarTypeCode { get; set; }

	[Position(09)]
	public string EquipmentStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E6_AdvanceCarDisposition>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.EquipmentStatusCode);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IntermediateSwitchCarrier, 2, 4);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		return validator.Results;
	}
}
