using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C233")]
public class C233_Service : EdifactComponent
{
	[Position(1)]
	public string ServiceRequirementCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ServiceRequirementCode2 { get; set; }

	[Position(5)]
	public string CodeListIdentificationCode2 { get; set; }

	[Position(6)]
	public string CodeListResponsibleAgencyCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C233_Service>(this);
		validator.Required(x=>x.ServiceRequirementCode);
		validator.Length(x => x.ServiceRequirementCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ServiceRequirementCode2, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode2, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode2, 1, 3);
		return validator.Results;
	}
}
