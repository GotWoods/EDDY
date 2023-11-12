using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("W12")]
public class W12_WarehouseItemDetail : EdiX12Segment
{
	[Position(01)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(04)]
	public decimal? QuantityDifference { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public string UPCCaseCode { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(08)]
	public string ProductServiceID { get; set; }

	[Position(09)]
	public string WarehouseLotNumber { get; set; }

	[Position(10)]
	public decimal? Weight { get; set; }

	[Position(11)]
	public string WeightQualifier { get; set; }

	[Position(12)]
	public string WeightUnitCode { get; set; }

	[Position(13)]
	public decimal? Weight2 { get; set; }

	[Position(14)]
	public string WeightQualifier2 { get; set; }

	[Position(15)]
	public string WeightUnitCode2 { get; set; }

	[Position(16)]
	public string UPCCaseCode2 { get; set; }

	[Position(17)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(18)]
	public string ProductServiceID2 { get; set; }

	[Position(19)]
	public string LineItemChangeReasonCode { get; set; }

	[Position(20)]
	public string WarehouseDetailAdjustmentIdentifier { get; set; }

	[Position(21)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(22)]
	public string ProductServiceID3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W12_WarehouseItemDetail>(this);
		validator.Required(x=>x.ShipmentOrderStatusCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.QuantityDifference, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.UPCCaseCode2, 12);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 48);
		validator.Length(x => x.LineItemChangeReasonCode, 2);
		validator.Length(x => x.WarehouseDetailAdjustmentIdentifier, 1);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 48);
		return validator.Results;
	}
}
