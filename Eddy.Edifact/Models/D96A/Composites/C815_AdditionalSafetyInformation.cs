using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C815")]
public class C815_AdditionalSafetyInformation : EdifactComponent
{
	[Position(1)]
	public string AdditionalSafetyInformationCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string AdditionalSafetyInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C815_AdditionalSafetyInformation>(this);
		validator.Required(x=>x.AdditionalSafetyInformationCoded);
		validator.Length(x => x.AdditionalSafetyInformationCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.AdditionalSafetyInformation, 1, 35);
		return validator.Results;
	}
}
