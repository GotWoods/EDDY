using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("CSF")]
public class CSF_ConditionalSamplingFrequency : EdiX12Segment
{
	[Position(01)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(02)]
	public decimal? SampleSelectionModulus { get; set; }

	[Position(03)]
	public int? SampleFrequencyValuePerUnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSF_ConditionalSamplingFrequency>(this);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.OnlyOneOf(x=>x.SampleSelectionModulus, x=>x.SampleFrequencyValuePerUnitOfMeasurementCode);
		validator.Length(x => x.SampleSelectionModulus, 1, 6);
		validator.Length(x => x.SampleFrequencyValuePerUnitOfMeasurementCode, 1, 9);
		return validator.Results;
	}
}
