using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C333")]
public class C333_InformationRequest : EdifactComponent
{
	[Position(1)]
	public string RequestedInformationCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string RequestedInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C333_InformationRequest>(this);
		validator.Length(x => x.RequestedInformationCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.RequestedInformation, 1, 35);
		return validator.Results;
	}
}
