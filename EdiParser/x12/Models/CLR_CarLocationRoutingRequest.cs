using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CLR")]
public class CLR_CarLocationRoutingRequest : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLR_CarLocationRoutingRequest>(this);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
