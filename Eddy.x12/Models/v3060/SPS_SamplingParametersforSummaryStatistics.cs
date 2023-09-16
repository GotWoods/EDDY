using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("SPS")]
public class SPS_SamplingParametersForSummaryStatistics : EdiX12Segment
{
	[Position(01)]
	public int? Count { get; set; }

	[Position(02)]
	public int? Count2 { get; set; }

	[Position(03)]
	public int? Count3 { get; set; }

	[Position(04)]
	public decimal? ConfidenceLimit { get; set; }

	[Position(05)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(06)]
	public int? SampleFrequencyValuePerUnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPS_SamplingParametersForSummaryStatistics>(this);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.Count2, 1, 9);
		validator.Length(x => x.Count3, 1, 9);
		validator.Length(x => x.ConfidenceLimit, 1, 4);
		validator.Length(x => x.SampleFrequencyValuePerUnitOfMeasurementCode, 1, 9);
		return validator.Results;
	}
}
