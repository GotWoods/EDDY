using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C827")]
public class C827_TypeOfMarking : EdifactComponent
{
	[Position(1)]
	public string TypeOfMarkingCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C827_TypeOfMarking>(this);
		validator.Required(x=>x.TypeOfMarkingCoded);
		validator.Length(x => x.TypeOfMarkingCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
