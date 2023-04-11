using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("ENE")]
public class ENE_ElectronicSystemsEnvironment : EdiX12Segment
{
	[Position(01)]
	public string CommunicationsEnvironmentCode { get; set; }

	[Position(02)]
	public string CommunicationNumberQualifier { get; set; }

	[Position(03)]
	public string CommunicationNumber { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ENE_ElectronicSystemsEnvironment>(this);
		validator.Required(x=>x.CommunicationsEnvironmentCode);
		validator.Required(x=>x.CommunicationNumberQualifier);
		validator.Required(x=>x.CommunicationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.CommunicationsEnvironmentCode, 2);
		validator.Length(x => x.CommunicationNumberQualifier, 2);
		validator.Length(x => x.CommunicationNumber, 1, 2048);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		return validator.Results;
	}
}
