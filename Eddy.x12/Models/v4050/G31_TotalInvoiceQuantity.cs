using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("G31")]
public class G31_TotalInvoiceQuantity : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

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
	public string PriceBracketIdentifier { get; set; }

	[Position(09)]
	public string PaymentMethodTypeCode { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public decimal? Weight2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G31_TotalInvoiceQuantity>(this);
		validator.Required(x=>x.NumberOfUnitsShipped);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode3);
		validator.ARequiresB(x=>x.OrderSizingFactor, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.OrderSizingFactor, 1, 10);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Weight2, 1, 10);
		return validator.Results;
	}
}
