using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TS2")]
public class TS2_TransactionSupplementalStatistics : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount6 { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount7 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount8 { get; set; }

	[Position(10)]
	public decimal? Quantity2 { get; set; }

	[Position(11)]
	public decimal? Quantity3 { get; set; }

	[Position(12)]
	public decimal? Quantity4 { get; set; }

	[Position(13)]
	public decimal? Quantity5 { get; set; }

	[Position(14)]
	public decimal? Quantity6 { get; set; }

	[Position(15)]
	public decimal? MonetaryAmount9 { get; set; }

	[Position(16)]
	public decimal? Quantity7 { get; set; }

	[Position(17)]
	public decimal? MonetaryAmount10 { get; set; }

	[Position(18)]
	public decimal? MonetaryAmount11 { get; set; }

	[Position(19)]
	public decimal? MonetaryAmount12 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TS2_TransactionSupplementalStatistics>(this);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.MonetaryAmount5, 1, 15);
		validator.Length(x => x.MonetaryAmount6, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount7, 1, 15);
		validator.Length(x => x.MonetaryAmount8, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.Quantity5, 1, 15);
		validator.Length(x => x.Quantity6, 1, 15);
		validator.Length(x => x.MonetaryAmount9, 1, 15);
		validator.Length(x => x.Quantity7, 1, 15);
		validator.Length(x => x.MonetaryAmount10, 1, 15);
		validator.Length(x => x.MonetaryAmount11, 1, 15);
		validator.Length(x => x.MonetaryAmount12, 1, 15);
		return validator.Results;
	}
}
