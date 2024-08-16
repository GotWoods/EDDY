using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C002")]
public class C002_DocumentMessageName : EdifactComponent
{
	[Position(1)]
	public string DocumentMessageNameCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string DocumentMessageName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C002_DocumentMessageName>(this);
		validator.Length(x => x.DocumentMessageNameCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.DocumentMessageName, 1, 35);
		return validator.Results;
	}
}
