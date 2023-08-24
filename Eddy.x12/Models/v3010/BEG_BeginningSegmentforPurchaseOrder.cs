using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BEG")]
public class BEG_BeginningSegmentForPurchaseOrder : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string PurchaseOrderTypeCode { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public string ReleaseNumber { get; set; }

	[Position(05)]
	public string PurchaseOrderDate { get; set; }

	[Position(06)]
	public string ContractNumber { get; set; }

	[Position(07)]
	public string AcknowledgmentType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BEG_BeginningSegmentForPurchaseOrder>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.PurchaseOrderTypeCode);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Required(x=>x.PurchaseOrderDate);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.PurchaseOrderTypeCode, 2);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderDate, 6);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.AcknowledgmentType, 2);
		return validator.Results;
	}
}
