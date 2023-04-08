using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("B9")]
public class B9_BeginningSegmentForLogisticsServices : EdiX12Segment 
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(03)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B9_BeginningSegmentForLogisticsServices>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		return validator.Results;
	}
}
