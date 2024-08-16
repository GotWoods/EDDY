using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("APP")]
public class APP_Applicability : EdifactSegment
{
	[Position(1)]
	public string ApplicabilityCodeQualifier { get; set; }

	[Position(2)]
	public C973_ApplicabilityType ApplicabilityType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<APP_Applicability>(this);
		validator.Length(x => x.ApplicabilityCodeQualifier, 1, 3);
		return validator.Results;
	}
}
