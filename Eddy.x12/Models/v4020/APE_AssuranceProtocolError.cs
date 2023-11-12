using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("APE")]
public class APE_AssuranceProtocolError : EdiX12Segment
{
	[Position(01)]
	public string BusinessPurposeOfAssurance { get; set; }

	[Position(02)]
	public string DomainOfComputationOfAssurance { get; set; }

	[Position(03)]
	public string SecurityOrAssuranceProtocolErrorCode { get; set; }

	[Position(04)]
	public string AssuranceOriginator { get; set; }

	[Position(05)]
	public string AssuranceRecipient { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<APE_AssuranceProtocolError>(this);
		validator.Required(x=>x.BusinessPurposeOfAssurance);
		validator.Required(x=>x.DomainOfComputationOfAssurance);
		validator.Required(x=>x.SecurityOrAssuranceProtocolErrorCode);
		validator.Length(x => x.BusinessPurposeOfAssurance, 3);
		validator.Length(x => x.DomainOfComputationOfAssurance, 1, 2);
		validator.Length(x => x.SecurityOrAssuranceProtocolErrorCode, 1, 2);
		validator.Length(x => x.AssuranceOriginator, 1, 64);
		validator.Length(x => x.AssuranceRecipient, 1, 64);
		return validator.Results;
	}
}
