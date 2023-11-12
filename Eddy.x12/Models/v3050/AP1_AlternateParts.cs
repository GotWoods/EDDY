using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("AP1")]
public class AP1_AlternateParts : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string PriceIdentifierCode { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string PostalCode { get; set; }

	[Position(07)]
	public string PostalCode2 { get; set; }

	[Position(08)]
	public string PrintOptionCode { get; set; }

	[Position(09)]
	public int? Number { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public string FreeFormMessage { get; set; }

	[Position(12)]
	public string ProductServiceID { get; set; }

	[Position(13)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AP1_AlternateParts>(this);
		validator.Required(x=>x.StatusCode);
		validator.ARequiresB(x=>x.PostalCode2, x=>x.PostalCode);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.PostalCode, 3, 11);
		validator.Length(x => x.PostalCode2, 3, 11);
		validator.Length(x => x.PrintOptionCode, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
