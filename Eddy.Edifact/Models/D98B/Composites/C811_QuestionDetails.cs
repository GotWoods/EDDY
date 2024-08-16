using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("C811")]
public class C811_QuestionDetails : EdifactComponent
{
	[Position(1)]
	public string QuestionCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Question { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C811_QuestionDetails>(this);
		validator.Length(x => x.QuestionCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Question, 1, 256);
		return validator.Results;
	}
}
