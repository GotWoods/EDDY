using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("CSB")]
public class CSB_CryptographicServiceMessageBody : EdiX12Segment
{
	[Position(01)]
	public string CryptographicServiceMessageCSMFieldTagCode { get; set; }

	[Position(02)]
	public string CryptographicServiceMessageCSMFieldContents { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSB_CryptographicServiceMessageBody>(this);
		validator.Required(x=>x.CryptographicServiceMessageCSMFieldTagCode);
		validator.Length(x => x.CryptographicServiceMessageCSMFieldTagCode, 2, 4);
		validator.Length(x => x.CryptographicServiceMessageCSMFieldContents, 1, 32);
		return validator.Results;
	}
}
