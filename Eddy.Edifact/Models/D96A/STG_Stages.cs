using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("STG")]
public class STG_Stages : EdifactSegment
{
	[Position(1)]
	public string StagesQualifier { get; set; }

	[Position(2)]
	public string NumberOfStages { get; set; }

	[Position(3)]
	public string ActualStageCount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STG_Stages>(this);
		validator.Required(x=>x.StagesQualifier);
		validator.Length(x => x.StagesQualifier, 1, 3);
		validator.Length(x => x.NumberOfStages, 1, 2);
		validator.Length(x => x.ActualStageCount, 1, 2);
		return validator.Results;
	}
}
