using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SCO")]
public class SCO_ShippersCarOrdered : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string CommodityCodeQualifier { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string CarTypeCode { get; set; }

	[Position(05)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(07)]
	public int? EquipmentLength { get; set; }

	[Position(08)]
	public decimal? Height { get; set; }

	[Position(09)]
	public decimal? Width { get; set; }

	[Position(10)]
	public int? WeightCapacity { get; set; }

	[Position(11)]
	public int? CubicCapacity { get; set; }

	[Position(12)]
	public string ProtectiveServiceCode { get; set; }

	[Position(13)]
	public int? Temperature { get; set; }

	[Position(14)]
	public string FloorTypeCode { get; set; }

	[Position(15)]
	public decimal? Height2 { get; set; }

	[Position(16)]
	public decimal? Width2 { get; set; }

	[Position(17)]
	public string DoorTypeCode { get; set; }

	[Position(18)]
	public string RatingSummaryValueCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCO_ShippersCarOrdered>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.CarTypeCode, 4);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.WeightCapacity, 2, 3);
		validator.Length(x => x.CubicCapacity, 2, 4);
		validator.Length(x => x.ProtectiveServiceCode, 1, 8);
		validator.Length(x => x.Temperature, 1, 3);
		validator.Length(x => x.FloorTypeCode, 1, 2);
		validator.Length(x => x.Height2, 1, 8);
		validator.Length(x => x.Width2, 1, 8);
		validator.Length(x => x.DoorTypeCode, 1, 2);
		validator.Length(x => x.RatingSummaryValueCode, 1);
		return validator.Results;
	}
}
