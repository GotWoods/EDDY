using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BOX")]
public class BOX_BoxOfficeDetail : EdiX12Segment
{
	[Position(01)]
	public string FrequencyCode { get; set; }

	[Position(02)]
	public string ShowCode { get; set; }

	[Position(03)]
	public string TicketCategoryCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string CurrencyCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public decimal? Quantity2 { get; set; }

	[Position(09)]
	public decimal? Quantity3 { get; set; }

	[Position(10)]
	public decimal? Quantity4 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(12)]
	public decimal? UnitPrice { get; set; }

	[Position(13)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(14)]
	public string ReferenceIdentification { get; set; }

	[Position(15)]
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BOX_BoxOfficeDetail>(this);
		validator.Required(x=>x.FrequencyCode);
		validator.Required(x=>x.ShowCode);
		validator.Required(x=>x.TicketCategoryCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.ShowCode, 2);
		validator.Length(x => x.TicketCategoryCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		return validator.Results;
	}
}
