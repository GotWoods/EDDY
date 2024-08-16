using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C585")]
public class C585_PriorityDetails : EdifactComponent
{
	[Position(1)]
	public string PriorityCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Priority { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C585_PriorityDetails>(this);
		validator.Length(x => x.PriorityCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Priority, 1, 35);
		return validator.Results;
	}
}