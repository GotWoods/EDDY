using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CSB")]
public class CSB_CryptographicServiceMessageBody : EdiX12Segment
{
	[Position(01)]
	public string CryptographicServiceMessageCSMFieldTag { get; set; }

	[Position(02)]
	public string CryptographicServiceMessageCSMFieldContents { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSB_CryptographicServiceMessageBody>(this);
		validator.Required(x=>x.CryptographicServiceMessageCSMFieldTag);
		validator.Length(x => x.CryptographicServiceMessageCSMFieldTag, 2, 4);
		validator.Length(x => x.CryptographicServiceMessageCSMFieldContents, 1, 32);
		return validator.Results;
	}
}
