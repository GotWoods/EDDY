using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G14")]
public class G14_TotalAllowanceChargeAdjustment : EdiX12Segment
{
	[Position(01)]
	public string CreditDebitFlagCode { get; set; }

	[Position(02)]
	public string AmountOfAdjustment { get; set; }

	[Position(03)]
	public string AdjustmentReasonCode { get; set; }

	[Position(04)]
	public string FreeFormDescription { get; set; }

	[Position(05)]
	public string AllowanceOrChargeCode { get; set; }

	[Position(06)]
	public string AllowanceOrChargeNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G14_TotalAllowanceChargeAdjustment>(this);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.Required(x=>x.AmountOfAdjustment);
		validator.Required(x=>x.AdjustmentReasonCode);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.AmountOfAdjustment, 2, 10);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.AllowanceOrChargeCode, 1, 3);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 16);
		return validator.Results;
	}
}
