using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ORI")]
public class ORI_ObjectReferenceIdentification : EdiX12Segment
{
	[Position(01)]
	public string AssociatedObjectReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ORI_ObjectReferenceIdentification>(this);
		validator.Required(x=>x.AssociatedObjectReferenceIdentification);
		validator.Length(x => x.AssociatedObjectReferenceIdentification, 1, 36);
		return validator.Results;
	}
}
