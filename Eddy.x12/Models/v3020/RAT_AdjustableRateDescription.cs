using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("RAT")]
public class RAT_AdjustableRateDescription : EdiX12Segment
{
	[Position(01)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string SourceOfInterestRateChangeCode { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	[Position(05)]
	public decimal? Percent2 { get; set; }

	[Position(06)]
	public decimal? Percent3 { get; set; }

	[Position(07)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(08)]
	public decimal? Quantity2 { get; set; }

	[Position(09)]
	public string UnitOfMeasurementCode3 { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RAT_AdjustableRateDescription>(this);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.SourceOfInterestRateChangeCode);
		validator.Required(x=>x.Percent);
		validator.Required(x=>x.Percent2);
		validator.Required(x=>x.Percent3);
		validator.Required(x=>x.UnitOfMeasurementCode2);
		validator.Required(x=>x.Quantity2);
		validator.ARequiresB(x=>x.Quantity3, x=>x.UnitOfMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Percent6, x=>x.RoundingSystemCode);
		validator.ARequiresB(x=>x.RateLifeCapSourceCode, x=>x.Percent4);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.SourceOfInterestRateChangeCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.Percent3, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Percent4, 1, 10);
		validator.Length(x => x.Percent5, 1, 10);
		validator.Length(x => x.Percent6, 1, 10);
		validator.Length(x => x.RoundingSystemCode, 1);
		validator.Length(x => x.RateLifeCapSourceCode, 1);
		return validator.Results;
	}
}
