using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BTI")]
public class BTI_BeginningTaxInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

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

	[Position(13)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(14)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTI_BeginningTaxInformation>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier3, x=>x.IdentificationCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier4, x=>x.IdentificationCode4);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.NameControlIdentifier, 1, 4);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		validator.Length(x => x.IdentificationCodeQualifier3, 1, 2);
		validator.Length(x => x.IdentificationCode3, 2, 80);
		validator.Length(x => x.IdentificationCodeQualifier4, 1, 2);
		validator.Length(x => x.IdentificationCode4, 2, 80);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
