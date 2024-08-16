using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E003")]
public class E003_AttributeInformation : EdifactComponent
{
	[Position(1)]
	public string AttributeTypeIdentification { get; set; }

	[Position(2)]
	public string Attribute { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E003_AttributeInformation>(this);
		validator.Required(x=>x.AttributeTypeIdentification);
		validator.Length(x => x.AttributeTypeIdentification, 1, 17);
		validator.Length(x => x.Attribute, 1, 35);
		return validator.Results;
	}
}
