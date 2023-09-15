using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G11")]
public class G11_AdjustmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string InvoiceDate { get; set; }

	[Position(02)]
	public string InvoiceNumber { get; set; }

	[Position(03)]
	public string PurchaseOrderDate { get; set; }

	[Position(04)]
	public string PurchaseOrderNumber { get; set; }

	[Position(05)]
	public string VendorOrderNumber { get; set; }

	[Position(06)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(07)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G11_AdjustmentIdentification>(this);
		validator.Required(x=>x.InvoiceDate);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.PurchaseOrderDate);
		validator.Length(x => x.InvoiceDate, 6);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.PurchaseOrderDate, 6);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
