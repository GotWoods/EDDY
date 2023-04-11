using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G68")]
public class G68_LineItemDetailProduct : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public decimal? ItemListCost { get; set; }

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
	public string PriceBracketIdentifier { get; set; }

	[Position(10)]
	public string QuantityCost { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(12)]
	public string PriceListNumber { get; set; }

	[Position(13)]
	public string PriceListIssueNumber { get; set; }

	[Position(14)]
	public string PrePriceQuantityDesignator { get; set; }

	[Position(15)]
	public decimal? RetailPrePrice { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G68_LineItemDetailProduct>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityCost, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ItemListCost, 1, 9);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.QuantityCost, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.PriceListNumber, 1, 16);
		validator.Length(x => x.PriceListIssueNumber, 1, 16);
		validator.Length(x => x.PrePriceQuantityDesignator, 1, 9);
		validator.Length(x => x.RetailPrePrice, 1, 9);
		return validator.Results;
	}
}
