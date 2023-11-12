using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G15")]
public class G15_TotalAdjustmentAmount : EdiX12Segment
{
	[Position(01)]
	public string AmountOfAdjustment { get; set; }

	[Position(02)]
	public string CreditDebitFlagCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G15_TotalAdjustmentAmount>(this);
		validator.Required(x=>x.AmountOfAdjustment);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Length(x => x.AmountOfAdjustment, 2, 10);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		return validator.Results;
	}
}
