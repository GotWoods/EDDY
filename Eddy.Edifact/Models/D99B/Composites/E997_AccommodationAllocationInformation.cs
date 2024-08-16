using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E997")]
public class E997_AccommodationAllocationInformation : EdifactComponent
{
	[Position(1)]
	public string ReferenceIdentifier { get; set; }

	[Position(2)]
	public string RelationshipDescriptionCode { get; set; }

	[Position(3)]
	public string SpecialRequirementTypeIdentification { get; set; }

	[Position(4)]
	public string CharacteristicValueCoded { get; set; }

	[Position(5)]
	public string SpecialRequirementDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E997_AccommodationAllocationInformation>(this);
		validator.Required(x=>x.ReferenceIdentifier);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		validator.Length(x => x.RelationshipDescriptionCode, 1, 3);
		validator.Length(x => x.SpecialRequirementTypeIdentification, 1, 4);
		validator.Length(x => x.CharacteristicValueCoded, 1, 3);
		validator.Length(x => x.SpecialRequirementDetail, 1, 17);
		return validator.Results;
	}
}
