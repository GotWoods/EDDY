using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("MIA")]
public class MIA_InpatientAdjudication : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Quantity2 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount6 { get; set; }

	[Position(10)]
	public decimal? MonetaryAmount7 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount8 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount9 { get; set; }

	[Position(13)]
	public decimal? MonetaryAmount10 { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount11 { get; set; }

	[Position(15)]
	public decimal? Quantity3 { get; set; }

	[Position(16)]
	public decimal? MonetaryAmount12 { get; set; }

	[Position(17)]
	public decimal? MonetaryAmount13 { get; set; }

	[Position(18)]
	public decimal? MonetaryAmount14 { get; set; }

	[Position(19)]
	public decimal? MonetaryAmount15 { get; set; }

	[Position(20)]
	public string ReferenceIdentification2 { get; set; }

	[Position(21)]
	public string ReferenceIdentification3 { get; set; }

	[Position(22)]
	public string ReferenceIdentification4 { get; set; }

	[Position(23)]
	public string ReferenceIdentification5 { get; set; }

	[Position(24)]
	public decimal? MonetaryAmount16 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIA_InpatientAdjudication>(this);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.MonetaryAmount5, 1, 18);
		validator.Length(x => x.MonetaryAmount6, 1, 18);
		validator.Length(x => x.MonetaryAmount7, 1, 18);
		validator.Length(x => x.MonetaryAmount8, 1, 18);
		validator.Length(x => x.MonetaryAmount9, 1, 18);
		validator.Length(x => x.MonetaryAmount10, 1, 18);
		validator.Length(x => x.MonetaryAmount11, 1, 18);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.MonetaryAmount12, 1, 18);
		validator.Length(x => x.MonetaryAmount13, 1, 18);
		validator.Length(x => x.MonetaryAmount14, 1, 18);
		validator.Length(x => x.MonetaryAmount15, 1, 18);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.ReferenceIdentification4, 1, 80);
		validator.Length(x => x.ReferenceIdentification5, 1, 80);
		validator.Length(x => x.MonetaryAmount16, 1, 18);
		return validator.Results;
	}
}
