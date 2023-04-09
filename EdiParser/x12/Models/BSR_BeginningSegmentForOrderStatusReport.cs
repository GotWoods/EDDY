using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BSR")]
public class BSR_BeginningSegmentForOrderStatusReport : EdiX12Segment
{
	[Position(01)]
	public string StatusReportCode { get; set; }

	[Position(02)]
	public string OrderItemCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string ProductDateCode { get; set; }

	[Position(06)]
	public string LocationCode { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

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
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Length(x => x.StatusReportCode, 1, 2);
		validator.Length(x => x.OrderItemCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ProductDateCode, 1, 2);
		validator.Length(x => x.LocationCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
