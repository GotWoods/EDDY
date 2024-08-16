using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C233")]
public class C233_Service : EdifactComponent
{
	[Position(1)]
	public string ServiceRequirementCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ServiceRequirementCoded2 { get; set; }

	[Position(5)]
	public string CodeListQualifier2 { get; set; }

	[Position(6)]
	public string CodeListResponsibleAgencyCoded2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C233_Service>(this);
		validator.Required(x=>x.ServiceRequirementCoded);
		validator.Length(x => x.ServiceRequirementCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ServiceRequirementCoded2, 1, 3);
		validator.Length(x => x.CodeListQualifier2, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded2, 1, 3);
		return validator.Results;
	}
}
