using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("COM")]
public class COM_CommunicationContact : EdifactSegment
{
	[Position(1)]
	public C076_CommunicationContact CommunicationContact { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COM_CommunicationContact>(this);
		validator.Required(x=>x.CommunicationContact);
		return validator.Results;
	}
}
