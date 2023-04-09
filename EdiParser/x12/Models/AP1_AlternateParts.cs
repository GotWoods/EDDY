using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AP1")]
public class AP1_AlternateParts : EdiX12Segment 
{
	[Position(01)]
	public string ConditionIndicatorCode { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string PriceIdentifierCode { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

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
	public string FreeFormInformation { get; set; }

	[Position(12)]
	public string ProductServiceID { get; set; }

	[Position(13)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AP1_AlternateParts>(this);
		validator.Required(x=>x.ConditionIndicatorCode);
		validator.ARequiresB(x=>x.PostalCode2, x=>x.PostalCode);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PostalCode, 3, 15);
		validator.Length(x => x.PostalCode2, 3, 15);
		validator.Length(x => x.PrintOptionCode, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
