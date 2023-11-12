using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("SCR")]
public class SCR_ShippersCarOrderedRail : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string CarTypeCode { get; set; }

	[Position(04)]
	public int? EquipmentLength { get; set; }

	[Position(05)]
	public decimal? Height { get; set; }

	[Position(06)]
	public decimal? Width { get; set; }

	[Position(07)]
	public int? WeightCapacity { get; set; }

	[Position(08)]
	public int? CubicCapacity { get; set; }

	[Position(09)]
	public string ProtectiveServiceRuleCode { get; set; }

	[Position(10)]
	public decimal? Temperature { get; set; }

	[Position(11)]
	public string FloorTypeCode { get; set; }

	[Position(12)]
	public decimal? Height2 { get; set; }

	[Position(13)]
	public decimal? Width2 { get; set; }

	[Position(14)]
	public string DoorTypeCode { get; set; }

	[Position(15)]
	public string RatingSummaryValueCode { get; set; }

	[Position(16)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(17)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(18)]
	public string CarTypeCode2 { get; set; }

	[Position(19)]
	public string AssociationOfAmericanRailroadsAARPoolCode { get; set; }

	[Position(20)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(21)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(22)]
	public string EquipmentInitial { get; set; }

	[Position(23)]
	public string EquipmentNumber { get; set; }

	[Position(24)]
	public string EquipmentNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCR_ShippersCarOrderedRail>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.CommodityCode);
		validator.AtLeastOneIsRequired(x=>x.CarTypeCode, x=>x.AssociationOfAmericanRailroadsAARPoolCode);
		validator.ARequiresB(x=>x.CarTypeCode2, x=>x.CarTypeCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.WeightCapacity, 2, 3);
		validator.Length(x => x.CubicCapacity, 2, 4);
		validator.Length(x => x.ProtectiveServiceRuleCode, 3, 9);
		validator.Length(x => x.Temperature, 1, 4);
		validator.Length(x => x.FloorTypeCode, 1, 2);
		validator.Length(x => x.Height2, 1, 8);
		validator.Length(x => x.Width2, 1, 8);
		validator.Length(x => x.DoorTypeCode, 1, 2);
		validator.Length(x => x.RatingSummaryValueCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.CarTypeCode2, 1, 4);
		validator.Length(x => x.AssociationOfAmericanRailroadsAARPoolCode, 7);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentNumber2, 1, 10);
		return validator.Results;
	}
}
