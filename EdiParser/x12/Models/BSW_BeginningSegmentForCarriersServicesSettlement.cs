using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BSW")]
public class BSW_BeginningSegmentForCarriersServicesSettlement : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(04)]
	public string NetAmountDue { get; set; }

	[Position(05)]
	public string BillingCode { get; set; }

	[Position(06)]
	public string CorrectionIndicatorCode { get; set; }

	[Position(07)]
	public string StatementNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSW_BeginningSegmentForCarriersServicesSettlement>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.NetAmountDue);
		validator.Required(x=>x.BillingCode);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.NetAmountDue, 1, 15);
		validator.Length(x => x.BillingCode, 1);
		validator.Length(x => x.CorrectionIndicatorCode, 2);
		validator.Length(x => x.StatementNumber, 1, 16);
		return validator.Results;
	}
}
