using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("AAA")]
public class AAA_RequestValidation : EdiX12Segment
{
	[Position(01)]
	public string ValidityCode { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string RejectReasonCode { get; set; }

	[Position(04)]
	public string FollowUpActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AAA_RequestValidation>(this);
		validator.Required(x=>x.ValidityCode);
		validator.Length(x => x.ValidityCode, 1);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.RejectReasonCode, 2);
		validator.Length(x => x.FollowUpActionCode, 1);
		return validator.Results;
	}
}
