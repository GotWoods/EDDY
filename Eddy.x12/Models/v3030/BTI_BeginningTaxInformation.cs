using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("BTI")]
public class BTI_BeginningTaxInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string NameControlIdentifier { get; set; }

	[Position(07)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(08)]
	public string IdentificationCode2 { get; set; }

	[Position(09)]
	public string IdentificationCodeQualifier3 { get; set; }

	[Position(10)]
	public string IdentificationCode3 { get; set; }

	[Position(11)]
	public string IdentificationCodeQualifier4 { get; set; }

	[Position(12)]
	public string IdentificationCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTI_BeginningTaxInformation>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier3, x=>x.IdentificationCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier4, x=>x.IdentificationCode4);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.NameControlIdentifier, 4);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 17);
		validator.Length(x => x.IdentificationCodeQualifier3, 1, 2);
		validator.Length(x => x.IdentificationCode3, 2, 17);
		validator.Length(x => x.IdentificationCodeQualifier4, 1, 2);
		validator.Length(x => x.IdentificationCode4, 2, 17);
		return validator.Results;
	}
}
