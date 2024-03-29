using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("POC")]
public class POC_LineItemChange : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string ChangeOrResponseTypeCode { get; set; }

	[Position(03)]
	public decimal? QuantityOrdered { get; set; }

	[Position(04)]
	public decimal? QuantityLeftToReceive { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(06)]
	public decimal? UnitPrice { get; set; }

	[Position(07)]
	public string BasisOfUnitPriceCode { get; set; }

	[Position(08)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(09)]
	public string ProductServiceID { get; set; }

	[Position(10)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(11)]
	public string ProductServiceID2 { get; set; }

	[Position(12)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(13)]
	public string ProductServiceID3 { get; set; }

	[Position(14)]
	public string ProductServiceIDQualifier4 { get; set; }

	[Position(15)]
	public string ProductServiceID4 { get; set; }

	[Position(16)]
	public string ProductServiceIDQualifier5 { get; set; }

	[Position(17)]
	public string ProductServiceID5 { get; set; }

	[Position(18)]
	public string ProductServiceIDQualifier6 { get; set; }

	[Position(19)]
	public string ProductServiceID6 { get; set; }

	[Position(20)]
	public string ProductServiceIDQualifier7 { get; set; }

	[Position(21)]
	public string ProductServiceID7 { get; set; }

	[Position(22)]
	public string ProductServiceIDQualifier8 { get; set; }

	[Position(23)]
	public string ProductServiceID8 { get; set; }

	[Position(24)]
	public string ProductServiceIDQualifier9 { get; set; }

	[Position(25)]
	public string ProductServiceID9 { get; set; }

	[Position(26)]
	public string ProductServiceIDQualifier10 { get; set; }

	[Position(27)]
	public string ProductServiceID10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<POC_LineItemChange>(this);
		validator.Required(x=>x.ChangeOrResponseTypeCode);
		validator.Length(x => x.AssignedIdentification, 1, 6);
		validator.Length(x => x.ChangeOrResponseTypeCode, 2);
		validator.Length(x => x.QuantityOrdered, 1, 9);
		validator.Length(x => x.QuantityLeftToReceive, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.BasisOfUnitPriceCode, 2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier4, 2);
		validator.Length(x => x.ProductServiceID4, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier5, 2);
		validator.Length(x => x.ProductServiceID5, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier6, 2);
		validator.Length(x => x.ProductServiceID6, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier7, 2);
		validator.Length(x => x.ProductServiceID7, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier8, 2);
		validator.Length(x => x.ProductServiceID8, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier9, 2);
		validator.Length(x => x.ProductServiceID9, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier10, 2);
		validator.Length(x => x.ProductServiceID10, 1, 30);
		return validator.Results;
	}
}
