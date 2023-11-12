using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("STA")]
public class STA_Statistics : EdiX12Segment
{
	[Position(01)]
	public string StatisticCode { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string MeasurementQualifier { get; set; }

	[Position(05)]
	public string MeasurementReferenceIDCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STA_Statistics>(this);
		validator.Required(x=>x.StatisticCode);
		validator.Required(x=>x.MeasurementValue);
		validator.Length(x => x.StatisticCode, 2);
		validator.Length(x => x.MeasurementValue, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.MeasurementReferenceIDCode, 2);
		return validator.Results;
	}
}
