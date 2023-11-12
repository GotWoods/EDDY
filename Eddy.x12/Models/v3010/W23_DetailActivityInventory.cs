using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W23")]
public class W23_DetailActivityInventory : EdiX12Segment
{
	[Position(01)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(02)]
	public decimal? BeginningBalanceQuantity { get; set; }

	[Position(03)]
	public decimal? QuantityAvailable { get; set; }

	[Position(04)]
	public decimal? EndingBalanceQuantity { get; set; }

	[Position(05)]
	public string UPCCaseCode { get; set; }

	[Position(06)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(07)]
	public string ProductServiceID { get; set; }

	[Position(08)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(09)]
	public string ProductServiceID2 { get; set; }

	[Position(10)]
	public decimal? QuantityReceived { get; set; }

	[Position(11)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(12)]
	public decimal? QuantityDamagedOnHold { get; set; }

	[Position(13)]
	public decimal? QuantityCommitted { get; set; }

	[Position(14)]
	public decimal? QuantityInTransit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W23_DetailActivityInventory>(this);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.BeginningBalanceQuantity);
		validator.Required(x=>x.QuantityAvailable);
		validator.Required(x=>x.EndingBalanceQuantity);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.BeginningBalanceQuantity, 1, 9);
		validator.Length(x => x.QuantityAvailable, 1, 9);
		validator.Length(x => x.EndingBalanceQuantity, 1, 9);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.QuantityDamagedOnHold, 1, 9);
		validator.Length(x => x.QuantityCommitted, 1, 9);
		validator.Length(x => x.QuantityInTransit, 1, 9);
		return validator.Results;
	}
}
