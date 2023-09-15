using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("BSR")]
public class BSR_BeginningSegmentForOrderStatusReport : EdiX12Segment
{
	[Position(01)]
	public string StatusReportCode { get; set; }

	[Position(02)]
	public string OrderItemCode { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string ProductDateCode { get; set; }

	[Position(06)]
	public string LocationCode { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string ReferenceNumber2 { get; set; }

	[Position(09)]
	public string Date2 { get; set; }

	[Position(10)]
	public string Time2 { get; set; }

	[Position(11)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(12)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSR_BeginningSegmentForOrderStatusReport>(this);
		validator.Required(x=>x.StatusReportCode);
		validator.Required(x=>x.OrderItemCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.StatusReportCode, 1, 2);
		validator.Length(x => x.OrderItemCode, 1, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ProductDateCode, 1, 2);
		validator.Length(x => x.LocationCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
