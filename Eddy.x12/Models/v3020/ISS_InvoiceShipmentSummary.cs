using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("ISS")]
public class ISS_InvoiceShipmentSummary : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(05)]
	public decimal? Volume { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISS_InvoiceShipmentSummary>(this);
		validator.ARequiresB(x=>x.NumberOfUnitsShipped, x=>x.UnitOfMeasurementCode);
		validator.ARequiresB(x=>x.Weight, x=>x.UnitOfMeasurementCode2);
		validator.ARequiresB(x=>x.Volume, x=>x.UnitOfMeasurementCode3);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		return validator.Results;
	}
}
