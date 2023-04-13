using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G82")]
public class G82_DeliveryReturnBaseRecordIdentifier : EdiX12Segment
{
	[Position(01)]
	public string CreditDebitFlagCode { get; set; }

	[Position(02)]
	public string SuppliersDeliveryReturnNumber { get; set; }

	[Position(03)]
	public string DUNSNumberCode { get; set; }

	[Position(04)]
	public string ReceiversLocationNumber { get; set; }

	[Position(05)]
	public string DUNSNumberCode2 { get; set; }

	[Position(06)]
	public string SuppliersLocationNumber { get; set; }

	[Position(07)]
	public string PhysicalDeliveryOrReturnDate { get; set; }

	[Position(08)]
	public string ProductOwnershipTransferDate { get; set; }

	[Position(09)]
	public string PurchaseOrderNumber { get; set; }

	[Position(10)]
	public string PurchaseOrderDate { get; set; }

	[Position(11)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(12)]
	public string CODMethodOfPaymentCode { get; set; }

	[Position(13)]
	public string ConditionIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G82_DeliveryReturnBaseRecordIdentifier>(this);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Required(x=>x.SuppliersDeliveryReturnNumber);
		validator.Required(x=>x.ReceiversLocationNumber);
		validator.Required(x=>x.SuppliersLocationNumber);
		validator.Required(x=>x.PhysicalDeliveryOrReturnDate);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.SuppliersDeliveryReturnNumber, 1, 22);
		validator.Length(x => x.DUNSNumberCode, 9);
		validator.Length(x => x.ReceiversLocationNumber, 1, 13);
		validator.Length(x => x.DUNSNumberCode2, 9);
		validator.Length(x => x.SuppliersLocationNumber, 1, 13);
		validator.Length(x => x.PhysicalDeliveryOrReturnDate, 8);
		validator.Length(x => x.ProductOwnershipTransferDate, 8);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.PurchaseOrderDate, 8);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.CODMethodOfPaymentCode, 1);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		return validator.Results;
	}
}
