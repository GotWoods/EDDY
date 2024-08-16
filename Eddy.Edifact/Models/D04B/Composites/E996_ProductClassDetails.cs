using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D04B.Composites;

[Segment("E996")]
public class E996_ProductClassDetails : EdifactComponent
{
	[Position(1)]
	public string CharacteristicDescriptionCode { get; set; }

	[Position(2)]
	public string RequestedInformationDescription { get; set; }

	[Position(3)]
	public string SpecialServiceDescriptionCode { get; set; }

	[Position(4)]
	public string ItemDescriptionCode { get; set; }

	[Position(5)]
	public string ItemDescriptionCode2 { get; set; }

	[Position(6)]
	public string ItemDescriptionCode3 { get; set; }

	[Position(7)]
	public string ProductCharacteristicIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E996_ProductClassDetails>(this);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		validator.Length(x => x.RequestedInformationDescription, 1, 35);
		validator.Length(x => x.SpecialServiceDescriptionCode, 1, 3);
		validator.Length(x => x.ItemDescriptionCode, 1, 17);
		validator.Length(x => x.ItemDescriptionCode2, 1, 17);
		validator.Length(x => x.ItemDescriptionCode3, 1, 17);
		validator.Length(x => x.ProductCharacteristicIdentificationCode, 1, 3);
		return validator.Results;
	}
}
