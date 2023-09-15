using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G01")]
public class G01_InvoiceIdentification : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string InvoiceNumber { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string PurchaseOrderNumber { get; set; }

	[Position(05)]
	public string VendorOrderNumber { get; set; }

	[Position(06)]
	public string MasterReferenceLinkNumber { get; set; }

	[Position(07)]
	public int? LinkSequenceNumber { get; set; }

	[Position(08)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G01_InvoiceIdentification>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.InvoiceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MasterReferenceLinkNumber, x=>x.LinkSequenceNumber);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		validator.Length(x => x.LinkSequenceNumber, 6);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
