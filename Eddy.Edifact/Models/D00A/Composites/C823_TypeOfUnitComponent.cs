using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C823")]
public class C823_TypeOfUnitComponent : EdifactComponent
{
	[Position(1)]
	public string UnitOrComponentTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string UnitOrComponentTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C823_TypeOfUnitComponent>(this);
		validator.Length(x => x.UnitOrComponentTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.UnitOrComponentTypeDescription, 1, 35);
		return validator.Results;
	}
}
