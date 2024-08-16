using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E989")]
public class E989_ProductIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string ProductIdentification { get; set; }

	[Position(2)]
	public string CharacteristicIdentification { get; set; }

	[Position(3)]
	public string ProductIdentificationCharacteristicCoded { get; set; }

	[Position(4)]
	public string ItemDescriptionIdentification { get; set; }

	[Position(5)]
	public string ItemDescriptionIdentification2 { get; set; }

	[Position(6)]
	public string ItemDescriptionIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E989_ProductIdentificationDetails>(this);
		validator.Length(x => x.ProductIdentification, 1, 35);
		validator.Length(x => x.CharacteristicIdentification, 1, 17);
		validator.Length(x => x.ProductIdentificationCharacteristicCoded, 1, 3);
		validator.Length(x => x.ItemDescriptionIdentification, 1, 17);
		validator.Length(x => x.ItemDescriptionIdentification2, 1, 17);
		validator.Length(x => x.ItemDescriptionIdentification3, 1, 17);
		return validator.Results;
	}
}
