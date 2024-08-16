using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S006")]
public class S006_ApplicationSendersIdentification : EdifactComponent
{
	[Position(1)]
	public string SenderIdentification { get; set; }

	[Position(2)]
	public string PartnerIdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S006_ApplicationSendersIdentification>(this);
		validator.Required(x=>x.SenderIdentification);
		validator.Length(x => x.SenderIdentification, 1, 35);
		validator.Length(x => x.PartnerIdentificationCodeQualifier, 1, 4);
		return validator.Results;
	}
}
