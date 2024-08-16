using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CPI")]
public class CPI_ChargePaymentInstructions : EdifactSegment
{
	[Position(1)]
	public C229_ChargeCategory ChargeCategory { get; set; }

	[Position(2)]
	public C231_MethodOfPayment MethodOfPayment { get; set; }

	[Position(3)]
	public string PrepaidCollectIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPI_ChargePaymentInstructions>(this);
		validator.Length(x => x.PrepaidCollectIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
