using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("PRD")]
public class PRD_MortgageLoanProductDescription : EdiX12Segment
{
	[Position(01)]
	public string LoanPaymentTypeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string RateValueQualifier { get; set; }

	[Position(04)]
	public string LoanRateTypeCode { get; set; }

	[Position(05)]
	public decimal? Percent { get; set; }

	[Position(06)]
	public decimal? Quantity2 { get; set; }

	[Position(07)]
	public decimal? Quantity3 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(10)]
	public decimal? Quantity4 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRD_MortgageLoanProductDescription>(this);
		validator.Required(x=>x.LoanPaymentTypeCode);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.LoanRateTypeCode, 1);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
