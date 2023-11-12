using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RE")]
public class RE_RebillAtInterchange : EdiX12Segment
{
	[Position(01)]
	public string RebillReasonCode { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(06)]
	public string CityName2 { get; set; }

	[Position(07)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(08)]
	public string FreightStationAccountingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RE_RebillAtInterchange>(this);
		validator.Required(x=>x.RebillReasonCode);
		validator.Required(x=>x.CityName);
		validator.Length(x => x.RebillReasonCode, 2);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.CityName2, 2, 19);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		return validator.Results;
	}
}
