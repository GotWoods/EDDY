using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("CSS")]
public class CSS_ConditionalSamplingSequence : EdiX12Segment
{
	[Position(01)]
	public string SamplingSequenceQualifier { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(03)]
	public int? SamplingSequenceValue { get; set; }

	[Position(04)]
	public int? SamplingSequenceValue2 { get; set; }

	[Position(05)]
	public int? SamplingSequenceValue3 { get; set; }

	[Position(06)]
	public int? SamplingSequenceValue4 { get; set; }

	[Position(07)]
	public int? SamplingSequenceValue5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSS_ConditionalSamplingSequence>(this);
		validator.Required(x=>x.SamplingSequenceQualifier);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Required(x=>x.SamplingSequenceValue);
		validator.Length(x => x.SamplingSequenceQualifier, 2);
		validator.Length(x => x.SamplingSequenceValue, 1, 3);
		validator.Length(x => x.SamplingSequenceValue2, 1, 3);
		validator.Length(x => x.SamplingSequenceValue3, 1, 3);
		validator.Length(x => x.SamplingSequenceValue4, 1, 3);
		validator.Length(x => x.SamplingSequenceValue5, 1, 3);
		return validator.Results;
	}
}
