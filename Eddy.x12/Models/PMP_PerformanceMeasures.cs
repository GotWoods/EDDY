using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PMP")]
public class PMP_PerformanceMeasures : EdiX12Segment
{
	[Position(01)]
	public string FrequencyPatternCode { get; set; }

	[Position(02)]
	public string OutOfStockDeterminationMethodCode { get; set; }

	[Position(03)]
	public string MeasurementQualifier { get; set; }

	[Position(04)]
	public string FrequencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PMP_PerformanceMeasures>(this);
		validator.Required(x=>x.FrequencyPatternCode);
		validator.Length(x => x.FrequencyPatternCode, 2);
		validator.Length(x => x.OutOfStockDeterminationMethodCode, 2);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.FrequencyCode, 1);
		return validator.Results;
	}
}
