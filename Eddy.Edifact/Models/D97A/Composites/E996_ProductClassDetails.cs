using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E996")]
public class E996_ProductClassDetails : EdifactComponent
{
	[Position(1)]
	public string CharacteristicIdentification { get; set; }

	[Position(2)]
	public string RequestedInformation { get; set; }

	[Position(3)]
	public string SpecialServicesCoded { get; set; }

	[Position(4)]
	public string ItemDescriptionIdentification { get; set; }

	[Position(5)]
	public string ItemDescriptionIdentification2 { get; set; }

	[Position(6)]
	public string ItemDescriptionIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E996_ProductClassDetails>(this);
		validator.Length(x => x.CharacteristicIdentification, 1, 17);
		validator.Length(x => x.RequestedInformation, 1, 35);
		validator.Length(x => x.SpecialServicesCoded, 1, 3);
		validator.Length(x => x.ItemDescriptionIdentification, 1, 17);
		validator.Length(x => x.ItemDescriptionIdentification2, 1, 17);
		validator.Length(x => x.ItemDescriptionIdentification3, 1, 17);
		return validator.Results;
	}
}
