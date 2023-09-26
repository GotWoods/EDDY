using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ISD")]
public class ISD_RailroadInterlineServiceDefinitionDetail : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public string EventCode { get; set; }

	[Position(04)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISD_RailroadInterlineServiceDefinitionDetail>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.EventCode);
		validator.Required(x=>x.Time);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.EventCode, 3);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
