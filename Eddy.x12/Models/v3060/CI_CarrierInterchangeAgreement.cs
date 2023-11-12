using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("CI")]
public class CI_CarrierInterchangeAgreement : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(06)]
	public string IdentificationCode2 { get; set; }

	[Position(07)]
	public string InterchangeAgreementStatusCode { get; set; }

	[Position(08)]
	public string DateTimeQualifier { get; set; }

	[Position(09)]
	public string Date { get; set; }

	[Position(10)]
	public string DateTimeQualifier2 { get; set; }

	[Position(11)]
	public string Date2 { get; set; }

	[Position(12)]
	public string Name2 { get; set; }

	[Position(13)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(14)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CI_CarrierInterchangeAgreement>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier2, x=>x.Date2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 20);
		validator.Length(x => x.InterchangeAgreementStatusCode, 1);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Name2, 1, 35);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
