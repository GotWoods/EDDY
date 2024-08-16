using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C944")]
public class C944_MembershipStatus : EdifactComponent
{
	[Position(1)]
	public string MembershipStatusCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MembershipStatus { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C944_MembershipStatus>(this);
		validator.Length(x => x.MembershipStatusCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MembershipStatus, 1, 35);
		return validator.Results;
	}
}
