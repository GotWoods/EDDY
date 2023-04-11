using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BSI")]
public class BSI_BeginningSegmentForOrderStatusInquiry : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string OrderItemCode { get; set; }

	[Position(04)]
	public string ProductDateCode { get; set; }

	[Position(05)]
	public string LocationCode { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(08)]
	public string TransactionTypeCode { get; set; }

	[Position(09)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSI_BeginningSegmentForOrderStatusInquiry>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.OrderItemCode);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.OrderItemCode, 1, 2);
		validator.Length(x => x.ProductDateCode, 1, 2);
		validator.Length(x => x.LocationCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
