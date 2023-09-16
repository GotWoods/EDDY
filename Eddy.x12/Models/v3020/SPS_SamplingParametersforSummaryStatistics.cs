using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SPS")]
public class SPS_SamplingParametersForSummaryStatistics : EdiX12Segment
{
	[Position(01)]
	public int? PopulationSizeCount { get; set; }

	[Position(02)]
	public int? SampleSizeCount { get; set; }

	[Position(03)]
	public int? SubgroupSizeCount { get; set; }

	[Position(04)]
	public decimal? ConfidenceLimit { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(06)]
	public int? SampleFrequencyValuePerUnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPS_SamplingParametersForSummaryStatistics>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOfMeasurementCode, x=>x.SampleFrequencyValuePerUnitOfMeasurementCode);
		validator.Length(x => x.PopulationSizeCount, 1, 9);
		validator.Length(x => x.SampleSizeCount, 1, 9);
		validator.Length(x => x.SubgroupSizeCount, 1, 9);
		validator.Length(x => x.ConfidenceLimit, 1, 4);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.SampleFrequencyValuePerUnitOfMeasurementCode, 1, 9);
		return validator.Results;
	}
}
