using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ISS")]
public class ISS_InvoiceShipmentSummary : EdiX12Segment
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
	public decimal? Quantity { get; set; }

	[Position(08)]
	public decimal? Weight2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISS_InvoiceShipmentSummary>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.NumberOfUnitsShipped, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode3);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Weight2, 1, 10);
		return validator.Results;
	}
}
