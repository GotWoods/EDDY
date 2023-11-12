using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("W07")]
public class W07_ItemDetailForStockReceipt : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityReceived { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string UPCCaseCode { get; set; }

	[Position(04)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(05)]
	public string ProductServiceID { get; set; }

	[Position(06)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(07)]
	public string ProductServiceID2 { get; set; }

	[Position(08)]
	public string WarehouseLotNumber { get; set; }

	[Position(09)]
	public string WarehouseDetailAdjustmentIdentifier { get; set; }

	[Position(10)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(11)]
	public string ProductServiceID3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W07_ItemDetailForStockReceipt>(this);
		validator.Required(x=>x.QuantityReceived);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.WarehouseDetailAdjustmentIdentifier, 1);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 40);
		return validator.Results;
	}
}
