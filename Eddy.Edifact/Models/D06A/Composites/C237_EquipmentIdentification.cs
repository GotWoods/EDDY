using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("C237")]
public class C237_EquipmentIdentification : EdifactComponent
{
	[Position(1)]
	public string EquipmentIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string CountryIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C237_EquipmentIdentification>(this);
		validator.Length(x => x.EquipmentIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.CountryIdentifier, 1, 3);
		return validator.Results;
	}
}