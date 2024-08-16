using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CLI")]
public class CLI_ClinicalIntervention : EdifactSegment
{
	[Position(1)]
	public string ClinicalInterventionTypeCodeQualifier { get; set; }

	[Position(2)]
	public C828_ClinicalInterventionDetails ClinicalInterventionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLI_ClinicalIntervention>(this);
		validator.Required(x=>x.ClinicalInterventionTypeCodeQualifier);
		validator.Length(x => x.ClinicalInterventionTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
