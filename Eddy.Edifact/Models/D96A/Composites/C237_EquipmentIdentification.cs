using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C237")]
public class C237_EquipmentIdentification : EdifactComponent
{
	[Position(1)]
	public string EquipmentIdentificationNumber { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string CountryCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C237_EquipmentIdentification>(this);
		validator.Length(x => x.EquipmentIdentificationNumber, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.CountryCoded, 1, 3);
		return validator.Results;
	}
}
