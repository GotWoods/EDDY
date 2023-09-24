using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("W21")]
public class W21_ItemDetailInventory : EdiX12Segment
{
	[Position(01)]
	public string WarehouseLotNumber { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public decimal? QuantityOnHand { get; set; }

	[Position(06)]
	public decimal? Weight { get; set; }

	[Position(07)]
	public string WeightQualifier { get; set; }

	[Position(08)]
	public string WeightUnitCode { get; set; }

	[Position(09)]
	public decimal? Weight2 { get; set; }

	[Position(10)]
	public string WeightQualifier2 { get; set; }

	[Position(11)]
	public string WeightUnitCode2 { get; set; }

	[Position(12)]
	public decimal? QuantityDamaged { get; set; }

	[Position(13)]
	public decimal? QuantityOnHold { get; set; }

	[Position(14)]
	public decimal? QuantityCommitted { get; set; }

	[Position(15)]
	public decimal? QuantityAvailable { get; set; }

	[Position(16)]
	public decimal? QuantityInTransit { get; set; }

	[Position(17)]
	public decimal? QuantityBackordered { get; set; }

	[Position(18)]
	public decimal? QuantityDeferred { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W21_ItemDetailInventory>(this);
		validator.Required(x=>x.WarehouseLotNumber);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.QuantityOnHand);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.QuantityOnHand, 1, 9);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.QuantityDamaged, 1, 9);
		validator.Length(x => x.QuantityOnHold, 1, 9);
		validator.Length(x => x.QuantityCommitted, 1, 9);
		validator.Length(x => x.QuantityAvailable, 1, 9);
		validator.Length(x => x.QuantityInTransit, 1, 9);
		validator.Length(x => x.QuantityBackordered, 1, 9);
		validator.Length(x => x.QuantityDeferred, 1, 9);
		return validator.Results;
	}
}
