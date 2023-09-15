using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G84")]
public class G84_DeliveryReturnRecordOfTotals : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string TotalInvoiceAmount { get; set; }

	[Position(03)]
	public string TotalDepositDollarAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G84_DeliveryReturnRecordOfTotals>(this);
		validator.AtLeastOneIsRequired(x=>x.Quantity, x=>x.TotalInvoiceAmount);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.TotalInvoiceAmount, 1, 10);
		validator.Length(x => x.TotalDepositDollarAmount, 1, 6);
		return validator.Results;
	}
}
