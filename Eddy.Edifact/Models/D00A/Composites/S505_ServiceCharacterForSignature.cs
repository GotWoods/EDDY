using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S505")]
public class S505_ServiceCharacterForSignature : EdifactComponent
{
	[Position(1)]
	public string ServiceCharacterForSignatureQualifier { get; set; }

	[Position(2)]
	public string ServiceCharacterForSignature { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S505_ServiceCharacterForSignature>(this);
		validator.Required(x=>x.ServiceCharacterForSignatureQualifier);
		validator.Required(x=>x.ServiceCharacterForSignature);
		validator.Length(x => x.ServiceCharacterForSignatureQualifier, 1, 3);
		validator.Length(x => x.ServiceCharacterForSignature, 1, 4);
		return validator.Results;
	}
}
