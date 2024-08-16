using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C828")]
public class C828_ClinicalInterventionDetails : EdifactComponent
{
	[Position(1)]
	public string ClinicalInterventionDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ClinicalInterventionDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C828_ClinicalInterventionDetails>(this);
		validator.Length(x => x.ClinicalInterventionDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ClinicalInterventionDescription, 1, 70);
		return validator.Results;
	}
}
