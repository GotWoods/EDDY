using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SPE")]
public class SPE_SecurityProtocolError : EdiX12Segment
{
	[Position(01)]
	public string SecurityOriginatorName { get; set; }

	[Position(02)]
	public string SecurityRecipientName { get; set; }

	[Position(03)]
	public string SecurityTypeCode { get; set; }

	[Position(04)]
	public string SecurityOrAssuranceProtocolErrorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPE_SecurityProtocolError>(this);
		validator.Required(x=>x.SecurityOriginatorName);
		validator.Required(x=>x.SecurityRecipientName);
		validator.Required(x=>x.SecurityTypeCode);
		validator.Required(x=>x.SecurityOrAssuranceProtocolErrorCode);
		validator.Length(x => x.SecurityOriginatorName, 1, 64);
		validator.Length(x => x.SecurityRecipientName, 1, 64);
		validator.Length(x => x.SecurityTypeCode, 2);
		validator.Length(x => x.SecurityOrAssuranceProtocolErrorCode, 1, 2);
		return validator.Results;
	}
}
