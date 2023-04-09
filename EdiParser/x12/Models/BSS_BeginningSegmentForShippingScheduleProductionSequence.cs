using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BSS")]
public class BSS_BeginningSegmentForShippingScheduleProductionSequence : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ScheduleTypeQualifier { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string Date3 { get; set; }

	[Position(07)]
	public string ReleaseNumber { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

	[Position(09)]
	public string ContractNumber { get; set; }

	[Position(10)]
	public string PurchaseOrderNumber { get; set; }

	[Position(11)]
	public string ScheduleQuantityQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSS_BeginningSegmentForShippingScheduleProductionSequence>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ScheduleTypeQualifier);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.Date3);
		validator.AtLeastOneIsRequired(x=>x.ReleaseNumber, x=>x.ReferenceIdentification2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ScheduleTypeQualifier, 2);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ScheduleQuantityQualifier, 1);
		return validator.Results;
	}
}
