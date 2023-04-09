using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("C4")]
public class C4_AlternateAmountDue : EdiX12Segment
{
	[Position(01)]
	public string CurrencyCode { get; set; }

	[Position(02)]
	public string NetAmountDue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C4_AlternateAmountDue>(this);
		validator.Required(x=>x.CurrencyCode);
		validator.Required(x=>x.NetAmountDue);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.NetAmountDue, 1, 15);
		return validator.Results;
	}
}
