using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C839")]
public class C839_AttendeeCategory : EdifactComponent
{
	[Position(1)]
	public string AttendeeCategoryDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AttendeeCategoryDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C839_AttendeeCategory>(this);
		validator.Length(x => x.AttendeeCategoryDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AttendeeCategoryDescription, 1, 35);
		return validator.Results;
	}
}
