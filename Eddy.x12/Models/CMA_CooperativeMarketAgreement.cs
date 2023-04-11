using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CMA")]
public class CMA_CooperativeMarketAgreement : EdiX12Segment
{
	[Position(01)]
	public string TransactionTypeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public int? Week { get; set; }

	[Position(06)]
	public string MarketAreaCodeQualifier { get; set; }

	[Position(07)]
	public string MarketAreaCodeIdentifier { get; set; }

	[Position(08)]
	public string CurrencyCode { get; set; }

	[Position(09)]
	public string MarketProfile { get; set; }

	[Position(10)]
	public string ContractNumber { get; set; }

	[Position(11)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CMA_CooperativeMarketAgreement>(this);
		validator.Required(x=>x.TransactionTypeCode);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Week);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MarketAreaCodeQualifier, x=>x.MarketAreaCodeIdentifier);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Week, 6);
		validator.Length(x => x.MarketAreaCodeQualifier, 1, 3);
		validator.Length(x => x.MarketAreaCodeIdentifier, 1, 13);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.MarketProfile, 1, 8);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
