using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PLI")]
public class PLI_PreviousLoanInformation : EdiX12Segment
{
	[Position(01)]
	public string LoanTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? InterestRate { get; set; }

	[Position(04)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(06)]
	public string DateTimePeriod { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string LoanRateTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLI_PreviousLoanInformation>(this);
		validator.Required(x=>x.LoanTypeCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.InterestRate);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.LoanRateTypeCode, 1);
		return validator.Results;
	}
}
