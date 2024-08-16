using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C823")]
public class C823_TypeOfUnitComponent : EdifactComponent
{
	[Position(1)]
	public string TypeOfUnitComponentCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string TypeOfUnitComponent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C823_TypeOfUnitComponent>(this);
		validator.Length(x => x.TypeOfUnitComponentCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.TypeOfUnitComponent, 1, 35);
		return validator.Results;
	}
}
