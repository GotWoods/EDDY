using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("IDB")]
public class IDB_IndebtednessForStudentLoans : EdiX12Segment
{
	[Position(01)]
	public string LoanTypeCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? InterestRate { get; set; }

	[Position(05)]
	public string LoanRateTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IDB_IndebtednessForStudentLoans>(this);
		validator.Required(x=>x.LoanTypeCode);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.InterestRate, x=>x.LoanRateTypeCode);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.LoanRateTypeCode, 1);
		return validator.Results;
	}
}
