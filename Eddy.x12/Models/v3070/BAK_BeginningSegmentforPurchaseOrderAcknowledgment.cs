using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("BAK")]
public class BAK_BeginningSegmentForPurchaseOrderAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string AcknowledgmentType { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public C041_CompositeDate CompositeDate { get; set; }

	[Position(05)]
	public string ReleaseNumber { get; set; }

	[Position(06)]
	public string RequestReferenceNumber { get; set; }

	[Position(07)]
	public string ContractNumber { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public C041_CompositeDate CompositeDate2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.AcknowledgmentType);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Required(x=>x.CompositeDate);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.AcknowledgmentType, 2);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.RequestReferenceNumber, 1, 45);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
