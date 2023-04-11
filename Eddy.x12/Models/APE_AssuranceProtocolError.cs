using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("APE")]
public class APE_AssuranceProtocolError : EdiX12Segment 
{
	[Position(01)]
	public string BusinessPurposeOfAssuranceCode { get; set; }

	[Position(02)]
	public string DomainOfComputationOfAssuranceCode { get; set; }

	[Position(03)]
	public string SecurityOrAssuranceProtocolErrorCode { get; set; }

	[Position(04)]
	public string AssuranceOriginator { get; set; }

	[Position(05)]
	public string AssuranceRecipient { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<APE_AssuranceProtocolError>(this);
		validator.Required(x=>x.BusinessPurposeOfAssuranceCode);
		validator.Required(x=>x.DomainOfComputationOfAssuranceCode);
		validator.Required(x=>x.SecurityOrAssuranceProtocolErrorCode);
		validator.Length(x => x.BusinessPurposeOfAssuranceCode, 3);
		validator.Length(x => x.DomainOfComputationOfAssuranceCode, 1, 2);
		validator.Length(x => x.SecurityOrAssuranceProtocolErrorCode, 1, 2);
		validator.Length(x => x.AssuranceOriginator, 1, 64);
		validator.Length(x => x.AssuranceRecipient, 1, 64);
		return validator.Results;
	}
}
