using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W19")]
public class W19_WarehouseAdjustmentItemDetail : EdiX12Segment
{
	[Position(01)]
	public string QuantityOrStatusAdjustmentReasonCode { get; set; }

	[Position(02)]
	public decimal? CreditDebitQuantity { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string UPCCaseCode { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(06)]
	public string ProductServiceID { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(08)]
	public string ProductServiceID2 { get; set; }

	[Position(09)]
	public string WarehouseLotNumber { get; set; }

	[Position(10)]
	public decimal? Weight { get; set; }

	[Position(11)]
	public string WeightQualifier { get; set; }

	[Position(12)]
	public string WeightUnitQualifier { get; set; }

	[Position(13)]
	public decimal? Weight2 { get; set; }

	[Position(14)]
	public string WeightQualifier2 { get; set; }

	[Position(15)]
	public string WeightUnitQualifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W19_WarehouseAdjustmentItemDetail>(this);
		validator.Required(x=>x.QuantityOrStatusAdjustmentReasonCode);
		validator.Required(x=>x.CreditDebitQuantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.QuantityOrStatusAdjustmentReasonCode, 2);
		validator.Length(x => x.CreditDebitQuantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.Weight2, 1, 8);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.WeightUnitQualifier2, 1);
		return validator.Results;
	}
}
