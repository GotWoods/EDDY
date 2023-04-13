using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G84")]
public class G84_DeliveryReturnRecordOfTotals : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string TotalInvoiceAmount { get; set; }

	[Position(03)]
	public string TotalDepositDollarAmount { get; set; }

	[Position(04)]
	public string TransactionTypeCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G84_DeliveryReturnRecordOfTotals>(this);
		validator.AtLeastOneIsRequired(x=>x.Quantity, x=>x.TotalInvoiceAmount);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.TotalInvoiceAmount, 1, 10);
		validator.Length(x => x.TotalDepositDollarAmount, 1, 6);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		return validator.Results;
	}
}
