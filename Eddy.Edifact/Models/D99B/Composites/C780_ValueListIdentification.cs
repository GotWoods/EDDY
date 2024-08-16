using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C780")]
public class C780_ValueListIdentification : EdifactComponent
{
	[Position(1)]
	public string ValueListIdentifier { get; set; }

	[Position(2)]
	public string ObjectIdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C780_ValueListIdentification>(this);
		validator.Required(x=>x.ValueListIdentifier);
		validator.Length(x => x.ValueListIdentifier, 1, 35);
		validator.Length(x => x.ObjectIdentificationCodeQualifier, 1, 3);
		return validator.Results;
	}
}
