using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PYM")]
public class PYM_PaymentMannerAndPercentage : EdiX12Segment
{
	[Position(01)]
	public string RatingCode { get; set; }

	[Position(02)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(03)]
	public int? NumberOfPeriods { get; set; }

	[Position(04)]
	public int? NumberOfPeriods2 { get; set; }

	[Position(05)]
	public string TimePeriodQualifier { get; set; }

	[Position(06)]
	public string RatingRemarksCode { get; set; }

	[Position(07)]
	public decimal? PercentageAsDecimal { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PYM_PaymentMannerAndPercentage>(this);
		validator.AtLeastOneIsRequired(x=>x.RatingCode, x=>x.RatingRemarksCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOfTimePeriodOrIntervalCode, x=>x.NumberOfPeriods);
		validator.ARequiresB(x=>x.NumberOfPeriods, x=>x.RatingCode);
		validator.ARequiresB(x=>x.NumberOfPeriods2, x=>x.NumberOfPeriods);
		validator.ARequiresB(x=>x.TimePeriodQualifier, x=>x.NumberOfPeriods);
		validator.Length(x => x.RatingCode, 2);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.NumberOfPeriods2, 1, 3);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.RatingRemarksCode, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		return validator.Results;
	}
}
