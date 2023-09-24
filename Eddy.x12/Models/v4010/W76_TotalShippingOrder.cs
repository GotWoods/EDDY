using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("W76")]
public class W76_TotalShippingOrder : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityOrdered { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Volume { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? OrderSizingFactor { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W76_TotalShippingOrder>(this);
		validator.Required(x=>x.QuantityOrdered);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode2);
		validator.ARequiresB(x=>x.OrderSizingFactor, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.QuantityOrdered, 1, 15);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.OrderSizingFactor, 1, 10);
		return validator.Results;
	}
}
