using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("W04")]
public class W04_ItemDetailTotal : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

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
	public string InboundConditionHoldCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W04_ItemDetailTotal>(this);
		validator.Required(x=>x.NumberOfUnitsShipped);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.FreightClassCode, 2, 5);
		validator.Length(x => x.RateClassCode, 1, 3);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.PalletBlockAndTiers, 6);
		validator.Length(x => x.InboundConditionHoldCode, 2);
		return validator.Results;
	}
}
