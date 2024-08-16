using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S002")]
public class S002_InterchangeSender : EdifactComponent
{
	[Position(1)]
	public string InterchangeSenderIdentification { get; set; }

	[Position(2)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(3)]
	public string InterchangeSenderInternalIdentification { get; set; }

	[Position(4)]
	public string InterchangeSenderInternalSubIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S002_InterchangeSender>(this);
		validator.Required(x=>x.InterchangeSenderIdentification);
		validator.Length(x => x.InterchangeSenderIdentification, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 4);
		validator.Length(x => x.InterchangeSenderInternalIdentification, 1, 35);
		validator.Length(x => x.InterchangeSenderInternalSubIdentification, 1, 35);
		return validator.Results;
	}
}
