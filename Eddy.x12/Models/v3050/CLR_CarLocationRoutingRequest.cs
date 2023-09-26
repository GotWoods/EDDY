using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CLR")]
public class CLR_CarLocationRoutingRequest : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLR_CarLocationRoutingRequest>(this);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.IndustryCode, 1, 20);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
