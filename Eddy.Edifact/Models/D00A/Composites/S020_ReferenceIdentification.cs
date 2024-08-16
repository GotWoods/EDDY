using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S020")]
public class S020_ReferenceIdentification : EdifactComponent
{
	[Position(1)]
	public string ReferenceQualifier { get; set; }

	[Position(2)]
	public string ReferenceIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S020_ReferenceIdentification>(this);
		validator.Required(x=>x.ReferenceQualifier);
		validator.Required(x=>x.ReferenceIdentificationNumber);
		validator.Length(x => x.ReferenceQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentificationNumber, 1, 35);
		return validator.Results;
	}
}
