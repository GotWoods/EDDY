using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("MIR")]
public class MIR_MortgageInsuranceResponse : EdiX12Segment
{
	[Position(01)]
	public string MortgageInsuranceApplicationType { get; set; }

	[Position(02)]
	public string UnderwritingDecisionCode { get; set; }

	[Position(03)]
	public string MortgageInsuranceCertificateTypeCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(06)]
	public string Amount { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public decimal? PercentageAsDecimal2 { get; set; }

	[Position(10)]
	public decimal? PercentageAsDecimal3 { get; set; }

	[Position(11)]
	public string MortgageInsuranceRenewalOptionCode { get; set; }

	[Position(12)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIR_MortgageInsuranceResponse>(this);
		validator.Required(x=>x.MortgageInsuranceApplicationType);
		validator.Required(x=>x.UnderwritingDecisionCode);
		validator.Length(x => x.MortgageInsuranceApplicationType, 1);
		validator.Length(x => x.UnderwritingDecisionCode, 1);
		validator.Length(x => x.MortgageInsuranceCertificateTypeCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PercentageAsDecimal2, 1, 10);
		validator.Length(x => x.PercentageAsDecimal3, 1, 10);
		validator.Length(x => x.MortgageInsuranceRenewalOptionCode, 1);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
