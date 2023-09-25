using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LRQ")]
public class LRQ_MortgageCharacteristicsRequested : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public decimal? Percent { get; set; }

	[Position(03)]
	public string RateValueQualifier { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public string TypeOfResidenceCode { get; set; }

	[Position(06)]
	public string ContactMethodCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string AssumptionTermsCode { get; set; }

	[Position(09)]
	public string LoanPurposeCode { get; set; }

	[Position(10)]
	public string PurposeOfRefinanceCode { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(13)]
	public string Description { get; set; }

	[Position(14)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LRQ_MortgageCharacteristicsRequested>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.MonetaryAmount2, x=>x.RateValueQualifier);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.TypeOfResidenceCode, 1);
		validator.Length(x => x.ContactMethodCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AssumptionTermsCode, 1);
		validator.Length(x => x.LoanPurposeCode, 2);
		validator.Length(x => x.PurposeOfRefinanceCode, 2);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
