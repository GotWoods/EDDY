using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

[Segment("LV")]
public class LV_LoanVerification : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string LoanVerificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LV_LoanVerification>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.LoanVerificationCode);
		validator.Length(x => x.AssignedNumber, 1, 9);
		validator.Length(x => x.LoanVerificationCode, 1, 2);
		return validator.Results;
	}
}
