using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C827")]
public class C827_TypeOfMarking : EdifactComponent
{
	[Position(1)]
	public string TypeOfMarkingCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C827_TypeOfMarking>(this);
		validator.Required(x=>x.TypeOfMarkingCoded);
		validator.Length(x => x.TypeOfMarkingCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
