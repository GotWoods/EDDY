using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E989")]
public class E989_ProductIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string ProductIdentifier { get; set; }

	[Position(2)]
	public string CharacteristicDescriptionCode { get; set; }

	[Position(3)]
	public string ProductCharacteristicIdentificationCode { get; set; }

	[Position(4)]
	public string ItemDescriptionCode { get; set; }

	[Position(5)]
	public string ItemDescriptionCode2 { get; set; }

	[Position(6)]
	public string ItemDescriptionCode3 { get; set; }

	[Position(7)]
	public string ProductName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E989_ProductIdentificationDetails>(this);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		validator.Length(x => x.ProductCharacteristicIdentificationCode, 1, 3);
		validator.Length(x => x.ItemDescriptionCode, 1, 17);
		validator.Length(x => x.ItemDescriptionCode2, 1, 17);
		validator.Length(x => x.ItemDescriptionCode3, 1, 17);
		validator.Length(x => x.ProductName, 1, 35);
		return validator.Results;
	}
}
