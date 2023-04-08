using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("ASM")]
public class ASM_AmountAndSettlementMethod : EdiX12Segment 
{
	[Position(01)]
	public string Amount { get; set; }

	[Position(02)]
	public string PaymentMethodTypeCode { get; set; }

	[Position(03)]
	public string AmountQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ASM_AmountAndSettlementMethod>(this);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		return validator.Results;
	}
}
