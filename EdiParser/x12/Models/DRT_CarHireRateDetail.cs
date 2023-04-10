using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DRT")]
public class DRT_CarHireRateDetail : EdiX12Segment
{
	[Position(01)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(02)]
	public string BilledRatedAsQualifier { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(05)]
	public string ChangeTypeCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DRT_CarHireRateDetail>(this);
		validator.ARequiresB(x=>x.MonetaryAmount, x=>x.BilledRatedAsQualifier);
		validator.OnlyOneOf(x=>x.MonetaryAmount, x=>x.PercentageAsDecimal);
		validator.ARequiresB(x=>x.PercentageAsDecimal, x=>x.BilledRatedAsQualifier);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.BilledRatedAsQualifier, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
