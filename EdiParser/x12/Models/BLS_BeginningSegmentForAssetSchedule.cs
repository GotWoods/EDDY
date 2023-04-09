using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BLS")]
public class BLS_BeginningSegmentForAssetSchedule : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string TransactionTypeCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string AcknowledgmentTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BLS_BeginningSegmentForAssetSchedule>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.TransactionTypeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.AcknowledgmentTypeCode, 2);
		return validator.Results;
	}
}
