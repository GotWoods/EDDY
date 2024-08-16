using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S007")]
public class S007_ApplicationRecipientsIdentification : EdifactComponent
{
	[Position(1)]
	public string RecipientsIdentification { get; set; }

	[Position(2)]
	public string PartnerIdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S007_ApplicationRecipientsIdentification>(this);
		validator.Required(x=>x.RecipientsIdentification);
		validator.Length(x => x.RecipientsIdentification, 1, 35);
		validator.Length(x => x.PartnerIdentificationCodeQualifier, 1, 4);
		return validator.Results;
	}
}
