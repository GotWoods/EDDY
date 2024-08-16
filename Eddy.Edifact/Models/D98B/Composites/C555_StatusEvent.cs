using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("C555")]
public class C555_Status : EdifactComponent
{
	[Position(1)]
	public string StatusCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Status { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C555_Status>(this);
		validator.Required(x=>x.StatusCoded);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Status, 1, 35);
		return validator.Results;
	}
}
