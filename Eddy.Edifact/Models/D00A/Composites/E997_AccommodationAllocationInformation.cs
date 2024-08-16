using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E997")]
public class E997_AccommodationAllocationInformation : EdifactComponent
{
	[Position(1)]
	public string ReferenceIdentifier { get; set; }

	[Position(2)]
	public string RelationshipDescriptionCode { get; set; }

	[Position(3)]
	public string SpecialRequirementTypeCode { get; set; }

	[Position(4)]
	public string CharacteristicValueDescriptionCode { get; set; }

	[Position(5)]
	public string SpecialRequirementDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E997_AccommodationAllocationInformation>(this);
		validator.Required(x=>x.ReferenceIdentifier);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		validator.Length(x => x.RelationshipDescriptionCode, 1, 3);
		validator.Length(x => x.SpecialRequirementTypeCode, 1, 4);
		validator.Length(x => x.CharacteristicValueDescriptionCode, 1, 3);
		validator.Length(x => x.SpecialRequirementDescription, 1, 17);
		return validator.Results;
	}
}
