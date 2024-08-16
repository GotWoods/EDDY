using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C004")]
public class C004_EventCategory : EdifactComponent
{
	[Position(1)]
	public string EventCategoryDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string EventCategoryDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C004_EventCategory>(this);
		validator.Length(x => x.EventCategoryDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.EventCategoryDescription, 1, 70);
		return validator.Results;
	}
}
