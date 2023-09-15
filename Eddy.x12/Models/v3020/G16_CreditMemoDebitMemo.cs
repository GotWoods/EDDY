using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G16")]
public class G16_CreditMemoDebitMemo : EdiX12Segment
{
	[Position(01)]
	public string CreditMemoDebitMemoDate { get; set; }

	[Position(02)]
	public string CreditDebitAdjustmentNumber { get; set; }

	[Position(03)]
	public string InvoiceDate { get; set; }

	[Position(04)]
	public string InvoiceNumber { get; set; }

	[Position(05)]
	public string VendorOrderNumber { get; set; }

	[Position(06)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(07)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G16_CreditMemoDebitMemo>(this);
		validator.Required(x=>x.CreditMemoDebitMemoDate);
		validator.Required(x=>x.CreditDebitAdjustmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.CreditMemoDebitMemoDate, 6);
		validator.Length(x => x.CreditDebitAdjustmentNumber, 1, 16);
		validator.Length(x => x.InvoiceDate, 6);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
