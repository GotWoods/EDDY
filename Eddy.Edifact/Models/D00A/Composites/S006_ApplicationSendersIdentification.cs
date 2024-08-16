using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S006")]
public class S006_ApplicationSenderIdentification : EdifactComponent
{
	[Position(1)]
	public string ApplicationSenderIdentification { get; set; }

	[Position(2)]
	public string IdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S006_ApplicationSenderIdentification>(this);
		validator.Required(x=>x.ApplicationSenderIdentification);
		validator.Length(x => x.ApplicationSenderIdentification, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 4);
		return validator.Results;
	}
}
