using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PUN")]
public class PUN_BeginningSegmentForMotorCarrierPickupNotification : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string Time2 { get; set; }

	[Position(06)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PUN_BeginningSegmentForMotorCarrierPickupNotification>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
