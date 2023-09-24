using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("XF")]
public class XF_SwitchAccomplishedInformation : EdiX12Segment
{
	[Position(01)]
	public string SwitchTypeCode { get; set; }

	[Position(02)]
	public string PlacePullIdentifierCode { get; set; }

	[Position(03)]
	public string Zone { get; set; }

	[Position(04)]
	public string Track { get; set; }

	[Position(05)]
	public string Spot { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XF_SwitchAccomplishedInformation>(this);
		validator.Required(x=>x.SwitchTypeCode);
		validator.Required(x=>x.PlacePullIdentifierCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Length(x => x.SwitchTypeCode, 2);
		validator.Length(x => x.PlacePullIdentifierCode, 1);
		validator.Length(x => x.Zone, 2, 3);
		validator.Length(x => x.Track, 2, 3);
		validator.Length(x => x.Spot, 2, 3);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
