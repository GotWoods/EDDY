using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IH")]
public class IH_InterconnectMailbagHeader : EdiX12Segment
{
	[Position(01)]
	public string InterconnectMailbagVersionNumberCode { get; set; }

	[Position(02)]
	public string InterconnectMailbagLogonID { get; set; }

	[Position(03)]
	public string InterconnectMailbagPassword { get; set; }

	[Position(04)]
	public string InterconnectMailbagIDQualifierCode { get; set; }

	[Position(05)]
	public string InterconnectMailbagSenderID { get; set; }

	[Position(06)]
	public string InterconnectMailbagIDQualifierCode2 { get; set; }

	[Position(07)]
	public string InterconnectMailbagReceiverID { get; set; }

	[Position(08)]
	public string InterconnectMailbagDate { get; set; }

	[Position(09)]
	public string InterconnectMailbagTime { get; set; }

	[Position(10)]
	public string InterconnectMailbagTimeCode { get; set; }

	[Position(11)]
	public int? InterconnectMailbagControlNumber { get; set; }

	[Position(12)]
	public string InterconnectMailbagTestIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IH_InterconnectMailbagHeader>(this);
		validator.Required(x=>x.InterconnectMailbagVersionNumberCode);
		validator.Required(x=>x.InterconnectMailbagIDQualifierCode);
		validator.Required(x=>x.InterconnectMailbagSenderID);
		validator.Required(x=>x.InterconnectMailbagIDQualifierCode2);
		validator.Required(x=>x.InterconnectMailbagReceiverID);
		validator.Required(x=>x.InterconnectMailbagDate);
		validator.Required(x=>x.InterconnectMailbagTime);
		validator.Required(x=>x.InterconnectMailbagTimeCode);
		validator.Required(x=>x.InterconnectMailbagControlNumber);
		validator.Required(x=>x.InterconnectMailbagTestIndicatorCode);
		validator.Length(x => x.InterconnectMailbagVersionNumberCode, 5);
		validator.Length(x => x.InterconnectMailbagLogonID, 1, 10);
		validator.Length(x => x.InterconnectMailbagPassword, 1, 10);
		validator.Length(x => x.InterconnectMailbagIDQualifierCode, 2);
		validator.Length(x => x.InterconnectMailbagSenderID, 1, 15);
		validator.Length(x => x.InterconnectMailbagIDQualifierCode2, 2);
		validator.Length(x => x.InterconnectMailbagReceiverID, 1, 15);
		validator.Length(x => x.InterconnectMailbagDate, 6);
		validator.Length(x => x.InterconnectMailbagTime, 6);
		validator.Length(x => x.InterconnectMailbagTimeCode, 2);
		validator.Length(x => x.InterconnectMailbagControlNumber, 1, 9);
		validator.Length(x => x.InterconnectMailbagTestIndicatorCode, 1);
		return validator.Results;
	}
}
