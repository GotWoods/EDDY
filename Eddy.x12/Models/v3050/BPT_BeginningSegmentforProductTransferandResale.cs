using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BPT")]
public class BPT_BeginningSegmentForProductTransferAndResale : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

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
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BPT_BeginningSegmentForProductTransferAndResale>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriceMultiplierQualifier, x=>x.Multiplier);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
