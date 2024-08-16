using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("C063")]
public class C063_EventIdentification : EdifactComponent
{
	[Position(1)]
	public string EventIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Event { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C063_EventIdentification>(this);
		validator.Length(x => x.EventIdentification, 1, 35);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Event, 1, 70);
		return validator.Results;
	}
}
