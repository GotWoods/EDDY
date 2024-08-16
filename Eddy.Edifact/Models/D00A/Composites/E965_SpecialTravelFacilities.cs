using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E965")]
public class E965_Facilities : EdifactComponent
{
	[Position(1)]
	public string FacilityTypeDescriptionCode { get; set; }

	[Position(2)]
	public string FacilityTypeDescription { get; set; }

	[Position(3)]
	public string ProductDetailsTypeCodeQualifier { get; set; }

	[Position(4)]
	public string CharacteristicDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E965_Facilities>(this);
		validator.Length(x => x.FacilityTypeDescriptionCode, 1, 3);
		validator.Length(x => x.FacilityTypeDescription, 1, 70);
		validator.Length(x => x.ProductDetailsTypeCodeQualifier, 1, 3);
		validator.Length(x => x.CharacteristicDescriptionCode, 1, 17);
		return validator.Results;
	}
}
