using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C549")]
public class C549_MonetaryFunction : EdifactComponent
{
	[Position(1)]
	public string MonetaryFunctionCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C549_MonetaryFunction>(this);
		validator.Required(x=>x.MonetaryFunctionCoded);
		validator.Length(x => x.MonetaryFunctionCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
