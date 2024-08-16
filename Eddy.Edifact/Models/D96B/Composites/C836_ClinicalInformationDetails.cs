using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C836")]
public class C836_ClinicalInformationDetails : EdifactComponent
{
	[Position(1)]
	public string ClinicalInformationIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ClinicalInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C836_ClinicalInformationDetails>(this);
		validator.Length(x => x.ClinicalInformationIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ClinicalInformation, 1, 70);
		return validator.Results;
	}
}
