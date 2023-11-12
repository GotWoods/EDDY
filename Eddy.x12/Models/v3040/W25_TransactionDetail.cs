using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("W25")]
public class W25_TransactionDetail : EdiX12Segment
{
	[Position(01)]
	public string InventoryTransactionTypeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(06)]
	public string ReferenceNumber { get; set; }

	[Position(07)]
	public decimal? Weight { get; set; }

	[Position(08)]
	public string WeightQualifier { get; set; }

	[Position(09)]
	public string WeightUnitCode { get; set; }

	[Position(10)]
	public decimal? Weight2 { get; set; }

	[Position(11)]
	public string WeightQualifier2 { get; set; }

	[Position(12)]
	public string WeightUnitCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W25_TransactionDetail>(this);
		validator.Required(x=>x.InventoryTransactionTypeCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.Date);
		validator.Length(x => x.InventoryTransactionTypeCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.WeightUnitCode2, 1);
		return validator.Results;
	}
}
