using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("ADJ")]
public class ADJ_AdjustmentsToBalancesOrServices : EdiX12Segment
{
	[Position(01)]
	public string AdjustmentApplicationCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public int? Number { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(09)]
	public string ProductServiceID { get; set; }

	[Position(10)]
	public string Amount { get; set; }

	[Position(11)]
	public string Amount2 { get; set; }

	[Position(12)]
	public string Amount3 { get; set; }

	[Position(13)]
	public decimal? Quantity { get; set; }

	[Position(14)]
	public decimal? Quantity2 { get; set; }

	[Position(15)]
	public decimal? Quantity3 { get; set; }

	[Position(16)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(17)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ADJ_AdjustmentsToBalancesOrServices>(this);
		validator.Required(x=>x.AdjustmentApplicationCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.Amount, x=>x.ProductServiceID);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount, x=>x.Amount2, x=>x.Amount3);
		validator.ARequiresB(x=>x.Amount2, x=>x.ProductServiceID);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount2, x=>x.Amount, x=>x.Amount3);
		validator.ARequiresB(x=>x.Amount3, x=>x.ProductServiceID);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount3, x=>x.Amount, x=>x.Amount2);
		validator.ARequiresB(x=>x.Quantity, x=>x.ProductServiceID);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Quantity, x=>x.Quantity2, x=>x.Quantity3);
		validator.ARequiresB(x=>x.Quantity2, x=>x.ProductServiceID);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Quantity2, x=>x.Quantity, x=>x.Quantity3);
		validator.ARequiresB(x=>x.Quantity3, x=>x.ProductServiceID);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Quantity3, x=>x.Quantity, x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.ARequiresB(x=>x.ReferenceIdentification, x=>x.ProductServiceID);
		validator.Length(x => x.AdjustmentApplicationCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 48);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.Amount3, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
