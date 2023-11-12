using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Models.v3050;

[Segment("STA")]
public class STA_Statistics : EdiX12Segment
{
	[Position(01)]
	public string StatisticCode { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(04)]
	public string MeasurementQualifier { get; set; }

	[Position(05)]
	public string MeasurementReferenceIDCode { get; set; }

	[Position(06)]
	public decimal? RangeMinimum { get; set; }

	[Position(07)]
	public decimal? RangeMaximum { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STA_Statistics>(this);
		validator.Required(x=>x.StatisticCode);
		validator.Required(x=>x.MeasurementValue);
		validator.Length(x => x.StatisticCode, 2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.MeasurementReferenceIDCode, 2);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		return validator.Results;
	}
}
