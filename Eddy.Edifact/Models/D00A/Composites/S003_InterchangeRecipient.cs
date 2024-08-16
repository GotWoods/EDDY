using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S003")]
public class S003_InterchangeRecipient : EdifactComponent
{
	[Position(1)]
	public string InterchangeRecipientIdentification { get; set; }

	[Position(2)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(3)]
	public string InterchangeRecipientInternalIdentification { get; set; }

	[Position(4)]
	public string InterchangeRecipientInternalSubIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S003_InterchangeRecipient>(this);
		validator.Required(x=>x.InterchangeRecipientIdentification);
		validator.Length(x => x.InterchangeRecipientIdentification, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 4);
		validator.Length(x => x.InterchangeRecipientInternalIdentification, 1, 35);
		validator.Length(x => x.InterchangeRecipientInternalSubIdentification, 1, 35);
		return validator.Results;
	}
}
