using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8020;

[Segment("SWC")]
public class SWC_SwitchingConditions : EdiX12Segment
{
	[Position(01)]
	public string SwitchingSettlementCode { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public string AmountCharged { get; set; }

	[Position(04)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SWC_SwitchingConditions>(this);
		validator.Required(x=>x.SwitchingSettlementCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardPointLocationCode2, x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.SwitchingSettlementCode, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.AmountCharged, 1, 15);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
