using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("G48")]
public class G48_StatementInvoiceIdentification : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string InvoiceDate { get; set; }

	[Position(03)]
	public string StoreNumber { get; set; }

	[Position(04)]
	public string PurchaseOrderDate { get; set; }

	[Position(05)]
	public string PurchaseOrderNumber { get; set; }

	[Position(06)]
	public string VendorOrderNumber { get; set; }

	[Position(07)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(08)]
	public int? LinkSequenceNumber { get; set; }

	[Position(09)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G48_StatementInvoiceIdentification>(this);
		validator.AtLeastOneIsRequired(x=>x.InvoiceNumber, x=>x.ReferenceNumberQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.InvoiceNumber, x=>x.InvoiceDate);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.InvoiceDate, 6);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.PurchaseOrderDate, 6);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.LinkSequenceNumber, 6);
		validator.Length(x => x.Date, 6);
		return validator.Results;
	}
}
