using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Models.v5030;

[Segment("MLA")]
public class MLA_MortgageLoanAuditInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ContractNumber { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string ServiceTypeCode { get; set; }

	[Position(06)]
	public string StatusCode { get; set; }

	[Position(07)]
	public C055_TaxServiceNonPaymentExceptionCode TaxServiceNonPaymentExceptionCode { get; set; }

	[Position(08)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MLA_MortgageLoanAuditInformation>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ContractNumber);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ServiceTypeCode, 1, 2);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
