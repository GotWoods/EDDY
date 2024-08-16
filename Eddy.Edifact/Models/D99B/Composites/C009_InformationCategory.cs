using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C009")]
public class C009_InformationCategory : EdifactComponent
{
	[Position(1)]
	public string InformationCategoryCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InformationCategoryDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C009_InformationCategory>(this);
		validator.Length(x => x.InformationCategoryCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InformationCategoryDescription, 1, 70);
		return validator.Results;
	}
}
