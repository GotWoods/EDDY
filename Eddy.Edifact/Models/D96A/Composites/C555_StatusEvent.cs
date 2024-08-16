using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C555")]
public class C555_StatusEvent : EdifactComponent
{
	[Position(1)]
	public string StatusEventCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string StatusEvent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C555_StatusEvent>(this);
		validator.Required(x=>x.StatusEventCoded);
		validator.Length(x => x.StatusEventCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.StatusEvent, 1, 35);
		return validator.Results;
	}
}
