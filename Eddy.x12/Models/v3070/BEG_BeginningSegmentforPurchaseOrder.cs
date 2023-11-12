using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Models.v3070;

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
	public C041_CompositeDate CompositeDate { get; set; }

	[Position(06)]
	public string ContractNumber { get; set; }

	[Position(07)]
	public string AcknowledgmentType { get; set; }

	[Position(08)]
	public string InvoiceTypeCode { get; set; }

	[Position(09)]
	public string ContractTypeCode { get; set; }

	[Position(10)]
	public string PurchaseCategory { get; set; }

	[Position(11)]
	public string SecurityLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BEG_BeginningSegmentForPurchaseOrder>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.PurchaseOrderTypeCode);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Required(x=>x.CompositeDate);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.PurchaseOrderTypeCode, 2);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.AcknowledgmentType, 2);
		validator.Length(x => x.InvoiceTypeCode, 3);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.PurchaseCategory, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		return validator.Results;
	}
}
