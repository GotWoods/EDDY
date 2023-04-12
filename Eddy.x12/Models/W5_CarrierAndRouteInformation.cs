using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("W5")]
public class W5_CarrierAndRouteInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(04)]
	public string CityName2 { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(06)]
	public string CityName3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W5_CarrierAndRouteInformation>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.CityName2, 2, 30);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.CityName3, 2, 30);
		return validator.Results;
	}
}
