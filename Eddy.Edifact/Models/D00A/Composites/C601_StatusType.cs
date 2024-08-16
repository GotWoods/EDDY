using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C601")]
public class C601_StatusCategory : EdifactComponent
{
	[Position(1)]
	public string StatusCategoryCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C601_StatusCategory>(this);
		validator.Required(x=>x.StatusCategoryCode);
		validator.Length(x => x.StatusCategoryCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}