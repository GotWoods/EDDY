using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("E083")]
public class E083_DeliveryPattern : EdifactComponent
{
	[Position(1)]
	public string QuantityTypeCodeQualifier { get; set; }

	[Position(2)]
	public string Quantity { get; set; }

	[Position(3)]
	public string MeasurementUnitCode { get; set; }

	[Position(4)]
	public string Quantity2 { get; set; }

	[Position(5)]
	public string PeriodTypeCode { get; set; }

	[Position(6)]
	public string PeriodCountQuantity { get; set; }

	[Position(7)]
	public string DespatchPatternCode { get; set; }

	[Position(8)]
	public string DespatchPatternTimingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E083_DeliveryPattern>(this);
		validator.Required(x=>x.QuantityTypeCodeQualifier);
		validator.Length(x => x.QuantityTypeCodeQualifier, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		validator.Length(x => x.Quantity2, 1, 35);
		validator.Length(x => x.PeriodTypeCode, 1, 3);
		validator.Length(x => x.PeriodCountQuantity, 1, 3);
		validator.Length(x => x.DespatchPatternCode, 1, 3);
		validator.Length(x => x.DespatchPatternTimingCode, 1, 3);
		return validator.Results;
	}
}
