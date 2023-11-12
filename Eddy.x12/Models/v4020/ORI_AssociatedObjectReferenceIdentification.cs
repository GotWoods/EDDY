using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("ORI")]
public class ORI_AssociatedObjectReferenceIdentification : EdiX12Segment
{
	[Position(01)]
	public string AssociatedObjectReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ORI_AssociatedObjectReferenceIdentification>(this);
		validator.Required(x=>x.AssociatedObjectReferenceIdentification);
		validator.Length(x => x.AssociatedObjectReferenceIdentification, 1, 36);
		return validator.Results;
	}
}
