using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E980")]
public class E980_SpecialRequirementTypeDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialRequirementTypeIdentification { get; set; }

	[Position(2)]
	public string StatusDescriptionCode { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	[Position(6)]
	public string LocationNameCode { get; set; }

	[Position(7)]
	public string LocationNameCode2 { get; set; }

	[Position(8)]
	public string CharacteristicDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E980_SpecialRequirementTypeDetails>(this);
		validator.Required(x=>x.SpecialRequirementTypeIdentification);
		validator.Length(x => x.SpecialRequirementTypeIdentification, 1, 4);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		validator.Length(x => x.LocationNameCode, 1, 25);
		validator.Length(x => x.LocationNameCode2, 1, 25);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		return validator.Results;
	}
}
