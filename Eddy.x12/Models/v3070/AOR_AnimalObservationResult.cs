using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("AOR")]
public class AOR_AnimalObservationResult : EdiX12Segment
{
	[Position(01)]
	public string ObservationDistribution { get; set; }

	[Position(02)]
	public string ObservationSeverity { get; set; }

	[Position(03)]
	public string NeoplasmCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string LinkageIdentifier { get; set; }

	[Position(06)]
	public string LinkageIdentifier2 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(08)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(09)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(10)]
	public int? TestPeriodOrIntervalValue2 { get; set; }

	[Position(11)]
	public string UnitOfTimePeriodOrInterval2 { get; set; }

	[Position(12)]
	public int? TestPeriodOrIntervalValue3 { get; set; }

	[Position(13)]
	public string UnitOfTimePeriodOrInterval3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AOR_AnimalObservationResult>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue, x=>x.UnitOfTimePeriodOrInterval);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue2, x=>x.UnitOfTimePeriodOrInterval2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue3, x=>x.UnitOfTimePeriodOrInterval3);
		validator.Length(x => x.ObservationDistribution, 1, 16);
		validator.Length(x => x.ObservationSeverity, 1, 17);
		validator.Length(x => x.NeoplasmCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.LinkageIdentifier, 1, 4);
		validator.Length(x => x.LinkageIdentifier2, 1, 4);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.TestPeriodOrIntervalValue2, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval2, 2);
		validator.Length(x => x.TestPeriodOrIntervalValue3, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval3, 2);
		return validator.Results;
	}
}
