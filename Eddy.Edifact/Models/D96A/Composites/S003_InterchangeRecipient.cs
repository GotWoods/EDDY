using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S003")]
public class S003_InterchangeRecipient : EdifactComponent
{
	[Position(1)]
	public string RecipientIdentification { get; set; }

	[Position(2)]
	public string PartnerIdentificationCodeQualifier { get; set; }

	[Position(3)]
	public string RoutingAddress { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S003_InterchangeRecipient>(this);
		validator.Required(x=>x.RecipientIdentification);
		validator.Length(x => x.RecipientIdentification, 1, 35);
		validator.Length(x => x.PartnerIdentificationCodeQualifier, 1, 4);
		validator.Length(x => x.RoutingAddress, 1, 14);
		return validator.Results;
	}
}
