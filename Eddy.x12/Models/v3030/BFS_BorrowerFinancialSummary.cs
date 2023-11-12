using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("BFS")]
public class BFS_BorrowerFinancialSummary : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string RateValueQualifier2 { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(09)]
	public string TypeOfIncomeCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BFS_BorrowerFinancialSummary>(this);
		validator.ARequiresB(x=>x.RateValueQualifier, x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.RateValueQualifier2, x=>x.MonetaryAmount2);
		validator.ARequiresB(x=>x.Date, x=>x.MonetaryAmount3);
		validator.ARequiresB(x=>x.Date2, x=>x.MonetaryAmount4);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.TypeOfIncomeCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
