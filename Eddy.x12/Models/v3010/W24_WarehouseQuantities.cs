using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W24")]
public class W24_WarehouseQuantities : EdiX12Segment
{
	[Position(01)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(02)]
	public string WarehouseLotNumber { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public decimal? BeginningBalanceQuantity { get; set; }

	[Position(06)]
	public decimal? QuantityAvailable { get; set; }

	[Position(07)]
	public decimal? EndingBalanceQuantity { get; set; }

	[Position(08)]
	public decimal? QuantityReceived { get; set; }

	[Position(09)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(10)]
	public decimal? QuantityDamagedOnHold { get; set; }

	[Position(11)]
	public decimal? QuantityAdjustment { get; set; }

	[Position(12)]
	public decimal? QuantityCommitted { get; set; }

	[Position(13)]
	public decimal? QuantityInTransit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W24_WarehouseQuantities>(this);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.WarehouseLotNumber);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.BeginningBalanceQuantity);
		validator.Required(x=>x.QuantityAvailable);
		validator.Required(x=>x.EndingBalanceQuantity);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.WarehouseLotNumber, 1, 12);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.BeginningBalanceQuantity, 1, 9);
		validator.Length(x => x.QuantityAvailable, 1, 9);
		validator.Length(x => x.EndingBalanceQuantity, 1, 9);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.QuantityDamagedOnHold, 1, 9);
		validator.Length(x => x.QuantityAdjustment, 1, 7);
		validator.Length(x => x.QuantityCommitted, 1, 9);
		validator.Length(x => x.QuantityInTransit, 1, 9);
		return validator.Results;
	}
}
