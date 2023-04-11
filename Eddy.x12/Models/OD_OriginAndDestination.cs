using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("OD")]
public class OD_OriginAndDestination : EdiX12Segment
{
	[Position(01)]
	public string StandardPointLocationCode { get; set; }

	[Position(02)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OD_OriginAndDestination>(this);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.StandardPointLocationCode2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		return validator.Results;
	}
}
