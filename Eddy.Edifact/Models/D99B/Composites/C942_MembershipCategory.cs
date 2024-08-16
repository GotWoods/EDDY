using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C942")]
public class C942_MembershipCategory : EdifactComponent
{
	[Position(1)]
	public string MembershipCategoryIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MembershipCategory { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C942_MembershipCategory>(this);
		validator.Required(x=>x.MembershipCategoryIdentification);
		validator.Length(x => x.MembershipCategoryIdentification, 1, 4);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MembershipCategory, 1, 35);
		return validator.Results;
	}
}