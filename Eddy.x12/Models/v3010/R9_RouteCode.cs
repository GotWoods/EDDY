using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("R9")]
public class R9_RouteCode : EdiX12Segment
{
	[Position(01)]
	public string RouteCode { get; set; }

	[Position(02)]
	public string AgentShipperRoutingCode { get; set; }

	[Position(03)]
	public string TOFCIntermodalCodeQualifier { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R9_RouteCode>(this);
		validator.Required(x=>x.RouteCode);
		validator.Required(x=>x.AgentShipperRoutingCode);
		validator.Length(x => x.RouteCode, 1, 13);
		validator.Length(x => x.AgentShipperRoutingCode, 1);
		validator.Length(x => x.TOFCIntermodalCodeQualifier, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
