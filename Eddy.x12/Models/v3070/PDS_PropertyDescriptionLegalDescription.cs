using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("PDS")]
public class PDS_PropertyDescriptionLegalDescription : EdiX12Segment
{
	[Position(01)]
	public string PropertyDescriptionQualifier { get; set; }

	[Position(02)]
	public string FreeFormMessageText { get; set; }

	[Position(03)]
	public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDS_PropertyDescriptionLegalDescription>(this);
		validator.Required(x=>x.PropertyDescriptionQualifier);
		validator.Length(x => x.PropertyDescriptionQualifier, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		return validator.Results;
	}
}
