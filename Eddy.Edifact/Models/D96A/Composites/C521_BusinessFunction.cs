using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C521")]
public class C521_BusinessFunction : EdifactComponent
{
	[Position(1)]
	public string BusinessFunctionQualifier { get; set; }

	[Position(2)]
	public string BusinessFunctionCoded { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(5)]
	public string BusinessDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C521_BusinessFunction>(this);
		validator.Required(x=>x.BusinessFunctionQualifier);
		validator.Required(x=>x.BusinessFunctionCoded);
		validator.Length(x => x.BusinessFunctionQualifier, 1, 3);
		validator.Length(x => x.BusinessFunctionCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.BusinessDescription, 1, 70);
		return validator.Results;
	}
}
