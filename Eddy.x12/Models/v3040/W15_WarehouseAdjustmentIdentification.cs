using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("W15")]
public class W15_WarehouseAdjustmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string WarehouseAdjustmentNumber { get; set; }

	[Position(03)]
	public string DepositorAdjustmentNumber { get; set; }

	[Position(04)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(05)]
	public string TransactionTypeCode { get; set; }

	[Position(06)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W15_WarehouseAdjustmentIdentification>(this);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WarehouseAdjustmentNumber, x=>x.DepositorAdjustmentNumber);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.WarehouseAdjustmentNumber, 1, 22);
		validator.Length(x => x.DepositorAdjustmentNumber, 1, 22);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
