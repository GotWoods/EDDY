using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("GDP")]
public class GDP_GeneralDosingParameters : EdiX12Segment
{
	[Position(01)]
	public decimal? MeasurementValue { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(03)]
	public string RouteOfAdministration { get; set; }

	[Position(04)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(05)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(06)]
	public int? TestPeriodOrIntervalValue2 { get; set; }

	[Position(07)]
	public string UnitOfTimePeriodOrIntervalCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GDP_GeneralDosingParameters>(this);
		validator.Required(x=>x.MeasurementValue);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue, x=>x.UnitOfTimePeriodOrIntervalCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue2, x=>x.UnitOfTimePeriodOrIntervalCode2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.RouteOfAdministration, 1, 20);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.TestPeriodOrIntervalValue2, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode2, 2);
		return validator.Results;
	}
}
