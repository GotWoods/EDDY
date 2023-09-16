using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PER")]
public class PER_AdministrativeCommunicationsContact : EdiX12Segment
{
	[Position(01)]
	public string ContactFunctionCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string CommunicationNumberQualifier { get; set; }

	[Position(04)]
	public string CommunicationNumber { get; set; }

	[Position(05)]
	public string CommunicationNumberQualifier2 { get; set; }

	[Position(06)]
	public string CommunicationNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PER_AdministrativeCommunicationsContact>(this);
		validator.Required(x=>x.ContactFunctionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommunicationNumberQualifier, x=>x.CommunicationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommunicationNumberQualifier2, x=>x.CommunicationNumber2);
		validator.Length(x => x.ContactFunctionCode, 2);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.CommunicationNumberQualifier, 2);
		validator.Length(x => x.CommunicationNumber, 1, 80);
		validator.Length(x => x.CommunicationNumberQualifier2, 2);
		validator.Length(x => x.CommunicationNumber2, 1, 80);
		return validator.Results;
	}
}
