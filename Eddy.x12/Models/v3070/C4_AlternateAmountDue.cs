using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

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
		validator.Length(x => x.NetAmountDue, 1, 12);
		return validator.Results;
	}
}
