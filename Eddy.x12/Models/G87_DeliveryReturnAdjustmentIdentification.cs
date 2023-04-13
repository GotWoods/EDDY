using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G87")]
public class G87_DeliveryReturnAdjustmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string InitiatorCode { get; set; }

	[Position(02)]
	public string CreditDebitFlagCode { get; set; }

	[Position(03)]
	public string SuppliersDeliveryReturnNumber { get; set; }

	[Position(04)]
	public string IntegrityCheckValue { get; set; }

	[Position(05)]
	public int? AdjustmentSequenceNumber { get; set; }

	[Position(06)]
	public string ReceiverDeliveryReturnNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G87_DeliveryReturnAdjustmentIdentification>(this);
		validator.Required(x=>x.InitiatorCode);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Required(x=>x.SuppliersDeliveryReturnNumber);
		validator.Required(x=>x.IntegrityCheckValue);
		validator.Required(x=>x.AdjustmentSequenceNumber);
		validator.Length(x => x.InitiatorCode, 1);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.SuppliersDeliveryReturnNumber, 1, 22);
		validator.Length(x => x.IntegrityCheckValue, 1, 12);
		validator.Length(x => x.AdjustmentSequenceNumber, 1);
		validator.Length(x => x.ReceiverDeliveryReturnNumber, 1, 22);
		return validator.Results;
	}
}
