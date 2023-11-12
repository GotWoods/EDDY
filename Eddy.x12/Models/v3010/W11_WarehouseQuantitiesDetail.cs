using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W11")]
public class W11_WarehouseQuantitiesDetail : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public decimal? BeginningBalanceQuantity { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(05)]
	public decimal? QuantityAvailable { get; set; }

	[Position(06)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(07)]
	public decimal? EndingBalanceQuantity { get; set; }

	[Position(08)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(09)]
	public decimal? QuantityReceived { get; set; }

	[Position(10)]
	public string UnitOfMeasurementCode4 { get; set; }

	[Position(11)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(12)]
	public string UnitOfMeasurementCode5 { get; set; }

	[Position(13)]
	public decimal? QuantityDamagedOnHold { get; set; }

	[Position(14)]
	public string UnitOfMeasurementCode6 { get; set; }

	[Position(15)]
	public decimal? QuantityOrdered { get; set; }

	[Position(16)]
	public string UnitOfMeasurementCode7 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W11_WarehouseQuantitiesDetail>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.BeginningBalanceQuantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.QuantityAvailable);
		validator.Required(x=>x.UnitOfMeasurementCode2);
		validator.Required(x=>x.EndingBalanceQuantity);
		validator.Required(x=>x.UnitOfMeasurementCode3);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.BeginningBalanceQuantity, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.QuantityAvailable, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.EndingBalanceQuantity, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.UnitOfMeasurementCode4, 2);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode5, 2);
		validator.Length(x => x.QuantityDamagedOnHold, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode6, 2);
		validator.Length(x => x.QuantityOrdered, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode7, 2);
		return validator.Results;
	}
}
