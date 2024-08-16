using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C945")]
public class C945_MembershipLevel : EdifactComponent
{
	[Position(1)]
	public string MembershipLevelCodeQualifier { get; set; }

	[Position(2)]
	public string MembershipLevelDescriptionCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(5)]
	public string MembershipLevelDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C945_MembershipLevel>(this);
		validator.Required(x=>x.MembershipLevelCodeQualifier);
		validator.Length(x => x.MembershipLevelCodeQualifier, 1, 3);
		validator.Length(x => x.MembershipLevelDescriptionCode, 1, 9);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MembershipLevelDescription, 1, 35);
		return validator.Results;
	}
}
