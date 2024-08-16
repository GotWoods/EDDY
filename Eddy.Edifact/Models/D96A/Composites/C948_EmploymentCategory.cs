using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C948")]
public class C948_EmploymentCategory : EdifactComponent
{
	[Position(1)]
	public string EmploymentCategoryCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string EmploymentCategory { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C948_EmploymentCategory>(this);
		validator.Length(x => x.EmploymentCategoryCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.EmploymentCategory, 1, 35);
		return validator.Results;
	}
}
