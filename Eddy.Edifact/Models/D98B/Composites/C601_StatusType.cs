using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("C601")]
public class C601_StatusCategory : EdifactComponent
{
	[Position(1)]
	public string StatusCategoryCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C601_StatusCategory>(this);
		validator.Required(x=>x.StatusCategoryCoded);
		validator.Length(x => x.StatusCategoryCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
