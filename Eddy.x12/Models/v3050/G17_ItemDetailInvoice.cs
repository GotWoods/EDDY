using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G17")]
public class G17_ItemDetailInvoice : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityInvoiced { get; set; }

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
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(12)]
	public string PriceListNumber { get; set; }

	[Position(13)]
	public string PriceListIssueNumber { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G17_ItemDetailInvoice>(this);
		validator.Required(x=>x.QuantityInvoiced);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.ItemListCost, x=>x.MonetaryAmount);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.NumberOfUnitsShipped, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.QuantityInvoiced, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ItemListCost, 1, 9);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.PriceListNumber, 1, 16);
		validator.Length(x => x.PriceListIssueNumber, 1, 16);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
