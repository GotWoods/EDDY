using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Models.v3070;

[Segment("RAT")]
public class RAT_AdjustableRateDescription : EdiX12Segment
{
	[Position(01)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string IndexIdentityCode { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public decimal? Percent2 { get; set; }

	[Position(06)]
	public decimal? Percent3 { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(08)]
	public decimal? Quantity2 { get; set; }

	[Position(09)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure3 { get; set; }

	[Position(10)]
	public decimal? Quantity3 { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(12)]
	public decimal? Percent4 { get; set; }

	[Position(13)]
	public decimal? Percent5 { get; set; }

	[Position(14)]
	public decimal? Percent6 { get; set; }

	[Position(15)]
	public string RoundingSystemCode { get; set; }

	[Position(16)]
	public string RateLifeCapSourceCode { get; set; }

	[Position(17)]
	public decimal? Percent7 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RAT_AdjustableRateDescription>(this);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.IndexIdentityCode);
		validator.Required(x=>x.Percent);
		validator.Required(x=>x.Percent2);
		validator.Required(x=>x.Percent3);
		validator.Required(x=>x.CompositeUnitOfMeasure2);
		validator.Required(x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Percent6, x=>x.RoundingSystemCode);
		validator.ARequiresB(x=>x.RateLifeCapSourceCode, x=>x.Percent4);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.IndexIdentityCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.Percent3, 1, 10);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Percent4, 1, 10);
		validator.Length(x => x.Percent5, 1, 10);
		validator.Length(x => x.Percent6, 1, 10);
		validator.Length(x => x.RoundingSystemCode, 1);
		validator.Length(x => x.RateLifeCapSourceCode, 1);
		validator.Length(x => x.Percent7, 1, 10);
		return validator.Results;
	}
}
