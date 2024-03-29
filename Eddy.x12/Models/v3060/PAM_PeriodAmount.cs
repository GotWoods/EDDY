using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("PAM")]
public class PAM_PeriodAmount : EdiX12Segment
{
	[Position(01)]
	public string QuantityQualifier { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public string AmountQualifierCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(07)]
	public string DateTimeQualifier { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string Time { get; set; }

	[Position(10)]
	public string DateTimeQualifier2 { get; set; }

	[Position(11)]
	public string Date2 { get; set; }

	[Position(12)]
	public string Time2 { get; set; }

	[Position(13)]
	public string PercentQualifier { get; set; }

	[Position(14)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAM_PeriodAmount>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOfTimePeriodOrInterval, x=>x.DateTimeQualifier);
		validator.ARequiresB(x=>x.DateTimeQualifier, x=>x.UnitOfTimePeriodOrInterval);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier, x=>x.Date, x=>x.Time);
		validator.ARequiresB(x=>x.Date, x=>x.DateTimeQualifier);
		validator.ARequiresB(x=>x.Time, x=>x.DateTimeQualifier);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier2, x=>x.Date2, x=>x.Time2);
		validator.ARequiresB(x=>x.Date2, x=>x.DateTimeQualifier2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentQualifier, x=>x.Percent);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
