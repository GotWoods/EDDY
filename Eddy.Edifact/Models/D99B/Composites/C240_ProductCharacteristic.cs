using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C240")]
public class C240_ProductCharacteristic : EdifactComponent
{
	[Position(1)]
	public string CharacteristicDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string CharacteristicDescription { get; set; }

	[Position(5)]
	public string CharacteristicDescription2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C240_ProductCharacteristic>(this);
		validator.Required(x=>x.CharacteristicDescriptionCode);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.CharacteristicDescription, 1, 35);
		validator.Length(x => x.CharacteristicDescription2, 1, 35);
		return validator.Results;
	}
}
