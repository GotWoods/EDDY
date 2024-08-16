using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C942")]
public class C942_MembershipCategory : EdifactComponent
{
	[Position(1)]
	public string MembershipCategoryDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MembershipCategoryDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C942_MembershipCategory>(this);
		validator.Required(x=>x.MembershipCategoryDescriptionCode);
		validator.Length(x => x.MembershipCategoryDescriptionCode, 1, 4);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MembershipCategoryDescription, 1, 35);
		return validator.Results;
	}
}
