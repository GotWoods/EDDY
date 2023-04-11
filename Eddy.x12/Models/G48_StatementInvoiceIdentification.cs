using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G48")]
public class G48_StatementInvoiceIdentification : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string StoreNumber { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	[Position(05)]
	public string PurchaseOrderNumber { get; set; }

	[Position(06)]
	public string VendorOrderNumber { get; set; }

	[Position(07)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string Date3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G48_StatementInvoiceIdentification>(this);
		validator.AtLeastOneIsRequired(x=>x.InvoiceNumber, x=>x.ReferenceIdentificationQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.InvoiceNumber, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date3, 8);
		return validator.Results;
	}
}
