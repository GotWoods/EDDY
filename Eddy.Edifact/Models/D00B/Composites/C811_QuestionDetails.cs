using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C811")]
public class C811_QuestionDetails : EdifactComponent
{
	[Position(1)]
	public string QuestionDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string QuestionDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C811_QuestionDetails>(this);
		validator.Length(x => x.QuestionDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.QuestionDescription, 1, 256);
		return validator.Results;
	}
}
