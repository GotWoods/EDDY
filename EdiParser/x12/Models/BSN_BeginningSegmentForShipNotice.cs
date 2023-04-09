using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BSN")]
public class BSN_BeginningSegmentForShipNotice : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ShipmentIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string HierarchicalStructureCode { get; set; }

	[Position(06)]
	public string TransactionTypeCode { get; set; }

	[Position(07)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSN_BeginningSegmentForShipNotice>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ShipmentIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.ARequiresB(x=>x.StatusReasonCode, x=>x.TransactionTypeCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ShipmentIdentification, 2, 30);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.HierarchicalStructureCode, 4);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
