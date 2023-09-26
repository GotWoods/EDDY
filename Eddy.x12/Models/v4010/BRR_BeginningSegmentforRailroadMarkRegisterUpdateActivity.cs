using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BRR")]
public class BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BRR_BeginningSegmentForRailroadMarkRegisterUpdateActivity>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
