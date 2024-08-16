using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S007")]
public class S007_ApplicationRecipientIdentification : EdifactComponent
{
	[Position(1)]
	public string ApplicationRecipientIdentification { get; set; }

	[Position(2)]
	public string IdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S007_ApplicationRecipientIdentification>(this);
		validator.Required(x=>x.ApplicationRecipientIdentification);
		validator.Length(x => x.ApplicationRecipientIdentification, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 4);
		return validator.Results;
	}
}
