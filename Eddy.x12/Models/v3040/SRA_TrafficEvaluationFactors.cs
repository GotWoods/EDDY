using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("SRA")]
public class SRA_TrafficEvaluationFactors : EdiX12Segment
{
	[Position(01)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SRA_TrafficEvaluationFactors>(this);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.MeasurementValue);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.MeasurementValue, 1, 10);
		return validator.Results;
	}
}
