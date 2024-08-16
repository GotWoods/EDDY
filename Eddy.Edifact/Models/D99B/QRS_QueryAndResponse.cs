using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("QRS")]
public class QRS_QueryAndResponse : EdifactSegment
{
	[Position(1)]
	public string SectorAreaIdentificationCodeQualifier { get; set; }

	[Position(2)]
	public C811_QuestionDetails QuestionDetails { get; set; }

	[Position(3)]
	public C812_ResponseDetails ResponseDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QRS_QueryAndResponse>(this);
		validator.Required(x=>x.SectorAreaIdentificationCodeQualifier);
		validator.Length(x => x.SectorAreaIdentificationCodeQualifier, 1, 3);
		return validator.Results;
	}
}
