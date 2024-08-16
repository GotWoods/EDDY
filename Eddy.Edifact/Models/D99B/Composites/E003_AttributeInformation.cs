using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E003")]
public class E003_AttributeInformation : EdifactComponent
{
	[Position(1)]
	public string AttributeTypeDescriptionCode { get; set; }

	[Position(2)]
	public string AttributeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E003_AttributeInformation>(this);
		validator.Required(x=>x.AttributeTypeDescriptionCode);
		validator.Length(x => x.AttributeTypeDescriptionCode, 1, 17);
		validator.Length(x => x.AttributeDescription, 1, 256);
		return validator.Results;
	}
}
