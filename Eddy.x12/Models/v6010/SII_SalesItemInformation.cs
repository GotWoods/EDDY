using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("SII")]
public class SII_SalesItemInformation : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(05)]
	public decimal? UnitPrice { get; set; }

	[Position(06)]
	public decimal? UnitPrice2 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SII_SalesItemInformation>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.UnitPrice2, 1, 17);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		return validator.Results;
	}
}
