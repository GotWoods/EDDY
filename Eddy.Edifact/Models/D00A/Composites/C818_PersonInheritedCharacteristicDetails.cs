using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C818")]
public class C818_PersonInheritedCharacteristicDetails : EdifactComponent
{
	[Position(1)]
	public string InheritedCharacteristicDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InheritedCharacteristicDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C818_PersonInheritedCharacteristicDetails>(this);
		validator.Length(x => x.InheritedCharacteristicDescriptionCode, 1, 8);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InheritedCharacteristicDescription, 1, 70);
		return validator.Results;
	}
}
