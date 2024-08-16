using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PER")]
public class PER_PeriodRelatedDetails : EdifactSegment
{
	[Position(1)]
	public string PeriodTypeCodeQualifier { get; set; }

	[Position(2)]
	public C977_PeriodDetail PeriodDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PER_PeriodRelatedDetails>(this);
		validator.Length(x => x.PeriodTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
