using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7030;

[Segment("AAA")]
public class AAA_RequestValidation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string RejectReasonCode { get; set; }

	[Position(04)]
	public string FollowUpActionCode { get; set; }

	[Position(05)]
	public string ErrorReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AAA_RequestValidation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.RejectReasonCode, 2);
		validator.Length(x => x.FollowUpActionCode, 1);
		validator.Length(x => x.ErrorReasonCode, 2);
		return validator.Results;
	}
}
