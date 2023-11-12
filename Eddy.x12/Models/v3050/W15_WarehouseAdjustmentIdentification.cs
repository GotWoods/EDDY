using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("W15")]
public class W15_WarehouseAdjustmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string AdjustmentNumber { get; set; }

	[Position(03)]
	public string AdjustmentNumber2 { get; set; }

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
		validator.IfOneIsFilled_AllAreRequired(x=>x.AdjustmentNumber, x=>x.AdjustmentNumber2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.AdjustmentNumber, 1, 22);
		validator.Length(x => x.AdjustmentNumber2, 1, 22);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
