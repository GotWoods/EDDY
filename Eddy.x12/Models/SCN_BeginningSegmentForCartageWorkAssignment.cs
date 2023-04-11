using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SCN")]
public class SCN_BeginningSegmentForCartageWorkAssignment : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(04)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCN_BeginningSegmentForCartageWorkAssignment>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
