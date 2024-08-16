using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("STG")]
public class STG_Stages : EdifactSegment
{
	[Position(1)]
	public string ProcessStageCodeQualifier { get; set; }

	[Position(2)]
	public string ProcessStagesQuantity { get; set; }

	[Position(3)]
	public string ProcessStagesActualQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STG_Stages>(this);
		validator.Required(x=>x.ProcessStageCodeQualifier);
		validator.Length(x => x.ProcessStageCodeQualifier, 1, 3);
		validator.Length(x => x.ProcessStagesQuantity, 1, 2);
		validator.Length(x => x.ProcessStagesActualQuantity, 1, 2);
		return validator.Results;
	}
}
