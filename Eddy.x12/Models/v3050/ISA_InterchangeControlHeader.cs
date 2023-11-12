using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ISA")]
public class ISA_InterchangeControlHeader : EdiX12Segment
{
	[Position(01)]
	public string AuthorizationInformationQualifier { get; set; }

	[Position(02)]
	public string AuthorizationInformation { get; set; }

	[Position(03)]
	public string SecurityInformationQualifier { get; set; }

	[Position(04)]
	public string SecurityInformation { get; set; }

	[Position(05)]
	public string InterchangeIDQualifier { get; set; }

	[Position(06)]
	public string InterchangeSenderID { get; set; }

	[Position(07)]
	public string InterchangeIDQualifier2 { get; set; }

	[Position(08)]
	public string InterchangeReceiverID { get; set; }

	[Position(09)]
	public string InterchangeDate { get; set; }

	[Position(10)]
	public string InterchangeTime { get; set; }

	[Position(11)]
	public string InterchangeControlStandardsIdentifier { get; set; }

	[Position(12)]
	public string InterchangeControlVersionNumber { get; set; }

	[Position(13)]
	public int? InterchangeControlNumber { get; set; }

	[Position(14)]
	public string AcknowledgmentRequested { get; set; }

	[Position(15)]
	public string TestIndicator { get; set; }

	[Position(16)]
	public string ComponentElementSeparator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISA_InterchangeControlHeader>(this);
		validator.Required(x=>x.AuthorizationInformationQualifier);
		validator.Required(x=>x.AuthorizationInformation);
		validator.Required(x=>x.SecurityInformationQualifier);
		validator.Required(x=>x.SecurityInformation);
		validator.Required(x=>x.InterchangeIDQualifier);
		validator.Required(x=>x.InterchangeSenderID);
		validator.Required(x=>x.InterchangeIDQualifier2);
		validator.Required(x=>x.InterchangeReceiverID);
		validator.Required(x=>x.InterchangeDate);
		validator.Required(x=>x.InterchangeTime);
		validator.Required(x=>x.InterchangeControlStandardsIdentifier);
		validator.Required(x=>x.InterchangeControlVersionNumber);
		validator.Required(x=>x.InterchangeControlNumber);
		validator.Required(x=>x.AcknowledgmentRequested);
		validator.Required(x=>x.TestIndicator);
		validator.Required(x=>x.ComponentElementSeparator);
		validator.Length(x => x.AuthorizationInformationQualifier, 2);
		validator.Length(x => x.AuthorizationInformation, 10);
		validator.Length(x => x.SecurityInformationQualifier, 2);
		validator.Length(x => x.SecurityInformation, 10);
		validator.Length(x => x.InterchangeIDQualifier, 2);
		validator.Length(x => x.InterchangeSenderID, 15);
		validator.Length(x => x.InterchangeIDQualifier2, 2);
		validator.Length(x => x.InterchangeReceiverID, 15);
		validator.Length(x => x.InterchangeDate, 6);
		validator.Length(x => x.InterchangeTime, 4);
		validator.Length(x => x.InterchangeControlStandardsIdentifier, 1);
		validator.Length(x => x.InterchangeControlVersionNumber, 5);
		validator.Length(x => x.InterchangeControlNumber, 9);
		validator.Length(x => x.AcknowledgmentRequested, 1);
		validator.Length(x => x.TestIndicator, 1);
		validator.Length(x => x.ComponentElementSeparator, 1);
		return validator.Results;
	}
}
