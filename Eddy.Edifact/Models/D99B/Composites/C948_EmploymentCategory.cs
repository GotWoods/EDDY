using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C948")]
public class C948_EmploymentCategory : EdifactComponent
{
	[Position(1)]
	public string EmploymentCategoryDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string EmploymentCategoryDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C948_EmploymentCategory>(this);
		validator.Length(x => x.EmploymentCategoryDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.EmploymentCategoryDescription, 1, 35);
		return validator.Results;
	}
}
