using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Models.v3070;

[Segment("ATR")]
public class ATR_AnimalTestResult : EdiX12Segment
{
	[Position(01)]
	public string TestTypeCode { get; set; }

	[Position(02)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(03)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(04)]
	public decimal? MeasurementValue { get; set; }

	[Position(05)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(06)]
	public string NonNumericTestValue { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(10)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATR_AnimalTestResult>(this);
		validator.Required(x=>x.TestTypeCode);
		validator.Required(x=>x.TestPeriodOrIntervalValue);
		validator.Required(x=>x.UnitOfTimePeriodOrInterval);
		validator.AtLeastOneIsRequired(x=>x.MeasurementValue, x=>x.NonNumericTestValue);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementValue, x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.TestTypeCode, 2);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.NonNumericTestValue, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
