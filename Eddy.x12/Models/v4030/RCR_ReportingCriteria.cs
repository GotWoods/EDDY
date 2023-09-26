using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("RCR")]
public class RCR_ReportingCriteria : EdiX12Segment
{
	[Position(01)]
	public string TimingQualifier { get; set; }

	[Position(02)]
	public string ActivityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RCR_ReportingCriteria>(this);
		validator.Required(x=>x.TimingQualifier);
		validator.Required(x=>x.ActivityCode);
		validator.Length(x => x.TimingQualifier, 1);
		validator.Length(x => x.ActivityCode, 2);
		return validator.Results;
	}
}
