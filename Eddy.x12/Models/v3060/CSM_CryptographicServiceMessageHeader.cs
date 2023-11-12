using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

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
		validator.Required(x=>x.SecurityOriginatorName);
		validator.Required(x=>x.SecurityRecipientName);
		validator.Length(x => x.CryptographicServiceMessageCSMMessageClassCode, 3, 4);
		validator.Length(x => x.SecurityOriginatorName, 1, 64);
		validator.Length(x => x.SecurityRecipientName, 1, 64);
		return validator.Results;
	}
}
