using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C076")]
public class C076_CommunicationContact : EdifactComponent
{
	[Position(1)]
	public string CommunicationNumber { get; set; }

	[Position(2)]
	public string CommunicationChannelQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C076_CommunicationContact>(this);
		validator.Required(x=>x.CommunicationNumber);
		validator.Required(x=>x.CommunicationChannelQualifier);
		validator.Length(x => x.CommunicationNumber, 1, 512);
		validator.Length(x => x.CommunicationChannelQualifier, 1, 3);
		return validator.Results;
	}
}