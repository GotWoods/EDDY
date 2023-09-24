using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("XD")]
public class XD_PlacementPullData : EdiX12Segment
{
	[Position(01)]
	public string SwitchTypeCode { get; set; }

	[Position(02)]
	public string Zone { get; set; }

	[Position(03)]
	public string Track { get; set; }

	[Position(04)]
	public string Spot { get; set; }

	[Position(05)]
	public string Spot2 { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XD_PlacementPullData>(this);
		validator.Required(x=>x.SwitchTypeCode);
		validator.Length(x => x.SwitchTypeCode, 2);
		validator.Length(x => x.Zone, 2, 3);
		validator.Length(x => x.Track, 2, 3);
		validator.Length(x => x.Spot, 2, 3);
		validator.Length(x => x.Spot2, 2, 3);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
