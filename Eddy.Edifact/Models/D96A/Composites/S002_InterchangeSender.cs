using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S002")]
public class S002_InterchangeSender : EdifactComponent
{
	[Position(1)]
	public string SenderIdentification { get; set; }

	[Position(2)]
	public string PartnerIdentificationCodeQualifier { get; set; }

	[Position(3)]
	public string AddressForReverseRouting { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S002_InterchangeSender>(this);
		validator.Required(x=>x.SenderIdentification);
		validator.Length(x => x.SenderIdentification, 1, 35);
		validator.Length(x => x.PartnerIdentificationCodeQualifier, 1, 4);
		validator.Length(x => x.AddressForReverseRouting, 1, 14);
		return validator.Results;
	}
}
