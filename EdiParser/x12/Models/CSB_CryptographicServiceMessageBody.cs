using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

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
