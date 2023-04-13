using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G76")]
public class G76_TotalPurchaseOrder : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(05)]
	public decimal? Volume { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(07)]
	public decimal? OrderSizingFactor { get; set; }

	[Position(08)]
	public string Amount { get; set; }

	[Position(09)]
	public string PriceBracketIdentifier { get; set; }

	[Position(10)]
	public string PaymentMethodTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G76_TotalPurchaseOrder>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode3);
		validator.ARequiresB(x=>x.OrderSizingFactor, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.OrderSizingFactor, 1, 10);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
		return validator.Results;
	}
}
