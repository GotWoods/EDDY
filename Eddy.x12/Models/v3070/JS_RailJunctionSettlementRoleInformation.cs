using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("JS")]
public class JS_RailJunctionSettlementRoleInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string RailJunctionSettlementRoleCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(04)]
	public string RailJunctionSettlementRoleCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<JS_RailJunctionSettlementRoleInformation>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.RailJunctionSettlementRoleCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.RailJunctionSettlementRoleCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.RailJunctionSettlementRoleCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.RailJunctionSettlementRoleCode2, 1);
		return validator.Results;
	}
}
