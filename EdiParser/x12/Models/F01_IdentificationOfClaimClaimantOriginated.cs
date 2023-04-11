using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("F01")]
public class F01_IdentificationOfClaimClaimantOriginated : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string SupportingEvidenceCode { get; set; }

	[Position(06)]
	public string CurrencyCode { get; set; }

	[Position(07)]
	public decimal? ExchangeRate { get; set; }

	[Position(08)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(09)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F01_IdentificationOfClaimClaimantOriginated>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.SupportingEvidenceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.SupportingEvidenceCode, 1);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.ExchangeRate, 4, 10);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		return validator.Results;
	}
}
