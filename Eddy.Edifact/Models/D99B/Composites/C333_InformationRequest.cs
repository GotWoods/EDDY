using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C333")]
public class C333_InformationRequest : EdifactComponent
{
	[Position(1)]
	public string RequestedInformationDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RequestedInformationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C333_InformationRequest>(this);
		validator.Length(x => x.RequestedInformationDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RequestedInformationDescription, 1, 35);
		return validator.Results;
	}
}
