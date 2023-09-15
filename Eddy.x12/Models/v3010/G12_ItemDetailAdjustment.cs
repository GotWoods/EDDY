using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G12")]
public class G12_ItemDetailAdjustment : EdiX12Segment
{
	[Position(01)]
	public string AdjustmentReasonCode { get; set; }

	[Position(02)]
	public string CreditDebitFlagCode { get; set; }

	[Position(03)]
	public decimal? CreditDebitQuantity { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(05)]
	public decimal? UnitPriceDifference { get; set; }

	[Position(06)]
	public string UPCCaseCode { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(08)]
	public string ProductServiceID { get; set; }

	[Position(09)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(10)]
	public string ProductServiceID2 { get; set; }

	[Position(11)]
	public string PriceBracketIdentifier { get; set; }

	[Position(12)]
	public string AmountOfAdjustment { get; set; }

	[Position(13)]
	public decimal? ItemListCostNew { get; set; }

	[Position(14)]
	public decimal? ItemListCostOld { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G12_ItemDetailAdjustment>(this);
		validator.Required(x=>x.AdjustmentReasonCode);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.CreditDebitQuantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UnitPriceDifference, 1, 9);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.AmountOfAdjustment, 2, 10);
		validator.Length(x => x.ItemListCostNew, 1, 9);
		validator.Length(x => x.ItemListCostOld, 1, 9);
		return validator.Results;
	}
}
