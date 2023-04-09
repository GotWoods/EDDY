using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BPT")]
public class BPT_BeginningSegmentForProductTransferAndResale : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ReportTypeCode { get; set; }

	[Position(05)]
	public string PriceMultiplierQualifier { get; set; }

	[Position(06)]
	public decimal? Multiplier { get; set; }

	[Position(07)]
	public string ActionCode { get; set; }

	[Position(08)]
	public string Time { get; set; }

	[Position(09)]
	public string ReferenceIdentification2 { get; set; }

	[Position(10)]
	public string SecurityLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BPT_BeginningSegmentForProductTransferAndResale>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriceMultiplierQualifier, x=>x.Multiplier);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.SecurityLevelCode, 2);
		return validator.Results;
	}
}
