using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C076")]
public class C076_CommunicationContact : EdifactComponent
{
	[Position(1)]
	public string CommunicationAddressIdentifier { get; set; }

	[Position(2)]
	public string CommunicationAddressCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C076_CommunicationContact>(this);
		validator.Required(x=>x.CommunicationAddressIdentifier);
		validator.Required(x=>x.CommunicationAddressCodeQualifier);
		validator.Length(x => x.CommunicationAddressIdentifier, 1, 512);
		validator.Length(x => x.CommunicationAddressCodeQualifier, 1, 3);
		return validator.Results;
	}
}