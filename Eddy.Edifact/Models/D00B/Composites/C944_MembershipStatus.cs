using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C944")]
public class C944_MembershipStatus : EdifactComponent
{
	[Position(1)]
	public string MembershipStatusDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MembershipStatusDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C944_MembershipStatus>(this);
		validator.Length(x => x.MembershipStatusDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MembershipStatusDescription, 1, 35);
		return validator.Results;
	}
}
