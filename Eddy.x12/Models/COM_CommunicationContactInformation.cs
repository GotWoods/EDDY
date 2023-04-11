using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("COM")]
public class COM_CommunicationContactInformation : EdiX12Segment
{
	[Position(01)]
	public string CommunicationNumberQualifier { get; set; }

	[Position(02)]
	public string CommunicationNumber { get; set; }

	[Position(03)]
	public C057_CommunicationNumberComponent CommunicationNumberComponent { get; set; }

	[Position(04)]
	public string LanguageCode { get; set; }

	[Position(05)]
	public string AssignedIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COM_CommunicationContactInformation>(this);
		validator.Required(x=>x.CommunicationNumberQualifier);
		validator.Required(x=>x.CommunicationNumber);
		validator.Length(x => x.CommunicationNumberQualifier, 2);
		validator.Length(x => x.CommunicationNumber, 1, 2048);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		return validator.Results;
	}
}
