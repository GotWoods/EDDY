using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("CLI")]
public class CLI_ClinicalIntervention : EdifactSegment
{
	[Position(1)]
	public string ClinicalInterventionQualifier { get; set; }

	[Position(2)]
	public C828_ClinicalInterventionDetails ClinicalInterventionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLI_ClinicalIntervention>(this);
		validator.Required(x=>x.ClinicalInterventionQualifier);
		validator.Length(x => x.ClinicalInterventionQualifier, 1, 3);
		return validator.Results;
	}
}
