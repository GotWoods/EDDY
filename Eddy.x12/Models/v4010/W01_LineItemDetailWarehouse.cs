using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("W01")]
public class W01_LineItemDetailWarehouse : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityOrdered { get; set; }

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
	public string FreightClassCode { get; set; }

	[Position(09)]
	public string RateClassCode { get; set; }

	[Position(10)]
	public string CommodityCodeQualifier { get; set; }

	[Position(11)]
	public string CommodityCode { get; set; }

	[Position(12)]
	public int? PalletBlockAndTiers { get; set; }

	[Position(13)]
	public string WarehouseLotNumber { get; set; }

	[Position(14)]
	public string ProductServiceConditionCode { get; set; }

	[Position(15)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(16)]
	public string ProductServiceID3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W01_LineItemDetailWarehouse>(this);
		validator.Required(x=>x.QuantityOrdered);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.Length(x => x.QuantityOrdered, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 48);
		validator.Length(x => x.FreightClassCode, 2, 5);
		validator.Length(x => x.RateClassCode, 1, 3);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.PalletBlockAndTiers, 6);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.ProductServiceConditionCode, 2);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 48);
		return validator.Results;
	}
}
