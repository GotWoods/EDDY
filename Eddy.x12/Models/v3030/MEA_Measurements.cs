using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("MEA")]
public class MEA_Measurements : EdiX12Segment
{
	[Position(01)]
	public string MeasurementReferenceIDCode { get; set; }

	[Position(02)]
	public string MeasurementQualifier { get; set; }

	[Position(03)]
	public decimal? MeasurementValue { get; set; }

	[Position(04)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(05)]
	public decimal? RangeMinimum { get; set; }

	[Position(06)]
	public decimal? RangeMaximum { get; set; }

	[Position(07)]
	public string MeasurementSignificanceCode { get; set; }

	[Position(08)]
	public string MeasurementAttributeCode { get; set; }

	[Position(09)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(10)]
	public string MeasurementMethodOrDevice { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MEA_Measurements>(this);
		validator.ARequiresB(x=>x.MeasurementValue, x=>x.CompositeUnitOfMeasure);
		validator.ARequiresB(x=>x.RangeMinimum, x=>x.CompositeUnitOfMeasure);
		validator.ARequiresB(x=>x.RangeMaximum, x=>x.CompositeUnitOfMeasure);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.MeasurementSignificanceCode, x=>x.MeasurementValue, x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.OnlyOneOf(x=>x.MeasurementAttributeCode, x=>x.MeasurementValue);
		validator.Length(x => x.MeasurementReferenceIDCode, 2);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.MeasurementValue, 1, 10);
		validator.Length(x => x.RangeMinimum, 1, 10);
		validator.Length(x => x.RangeMaximum, 1, 10);
		validator.Length(x => x.MeasurementSignificanceCode, 2);
		validator.Length(x => x.MeasurementAttributeCode, 2);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.MeasurementMethodOrDevice, 2, 4);
		return validator.Results;
	}
}
