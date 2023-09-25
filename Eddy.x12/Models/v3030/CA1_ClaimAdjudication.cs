using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CA1")]
public class CA1_ClaimAdjudication : EdiX12Segment
{
	[Position(01)]
	public string PaymentStatusCode { get; set; }

	[Position(02)]
	public string ClaimAdjustmentReasonCode { get; set; }

	[Position(03)]
	public string ClaimAdjustmentReasonCode2 { get; set; }

	[Position(04)]
	public string ClaimAdjustmentReasonCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CA1_ClaimAdjudication>(this);
		validator.Required(x=>x.PaymentStatusCode);
		validator.Length(x => x.PaymentStatusCode, 1);
		validator.Length(x => x.ClaimAdjustmentReasonCode, 1, 5);
		validator.Length(x => x.ClaimAdjustmentReasonCode2, 1, 5);
		validator.Length(x => x.ClaimAdjustmentReasonCode3, 1, 5);
		return validator.Results;
	}
}
