using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010.Composites;

namespace Eddy.x12.Models.v7010;

[Segment("COM")]
public class COM_CommunicationContactInformation : EdiX12Segment
{
	[Position(01)]
	public string CommunicationNumberQualifier { get; set; }

	[Position(02)]
	public string CommunicationNumber { get; set; }

	[Position(03)]
	public C057_CommunicationNumberComponent CommunicationNumberComponent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COM_CommunicationContactInformation>(this);
		validator.Required(x=>x.CommunicationNumberQualifier);
		validator.Required(x=>x.CommunicationNumber);
		validator.Length(x => x.CommunicationNumberQualifier, 2);
		validator.Length(x => x.CommunicationNumber, 1, 2048);
		return validator.Results;
	}
}
