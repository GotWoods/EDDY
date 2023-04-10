using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CSM")]
public class CSM_CryptographicServiceMessageHeader : EdiX12Segment
{
	[Position(01)]
	public string CryptographicServiceMessageCSMMessageClassCode { get; set; }

	[Position(02)]
	public string SecurityOriginatorName { get; set; }

	[Position(03)]
	public string SecurityRecipientName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSM_CryptographicServiceMessageHeader>(this);
		validator.Required(x=>x.CryptographicServiceMessageCSMMessageClassCode);
		validator.Length(x => x.CryptographicServiceMessageCSMMessageClassCode, 3, 4);
		validator.Length(x => x.SecurityOriginatorName, 1, 64);
		validator.Length(x => x.SecurityRecipientName, 1, 64);
		return validator.Results;
	}
}