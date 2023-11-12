using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("DAD")]
public class DAD_DebitAuthorizationDetail : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string TransactionHandlingCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	[Position(05)]
	public string OriginatingCompanyIdentifier { get; set; }

	[Position(06)]
	public string OriginatingCompanySupplementalCode { get; set; }

	[Position(07)]
	public string AmountQualifierCode { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string ReferenceIdentification2 { get; set; }

	[Position(11)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(12)]
	public string DFIIdentificationNumber { get; set; }

	[Position(13)]
	public string AccountNumber { get; set; }

	[Position(14)]
	public int? Number { get; set; }

	[Position(15)]
	public string FrequencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DAD_DebitAuthorizationDetail>(this);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.ReferenceIdentification2, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DFIIDNumberQualifier, x=>x.DFIIdentificationNumber);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.OriginatingCompanyIdentifier, 10);
		validator.Length(x => x.OriginatingCompanySupplementalCode, 9);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.FrequencyCode, 1);
		return validator.Results;
	}
}
