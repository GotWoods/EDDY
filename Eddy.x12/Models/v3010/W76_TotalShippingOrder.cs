using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W76")]
public class W76_TotalShippingOrder : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityOrdered { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Volume { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? EquivalentWeight { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W76_TotalShippingOrder>(this);
		validator.Required(x=>x.QuantityOrdered);
		validator.Length(x => x.QuantityOrdered, 1, 9);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.EquivalentWeight, 1, 10);
		return validator.Results;
	}
}
