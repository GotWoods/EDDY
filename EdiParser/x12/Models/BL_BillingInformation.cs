using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BL")]
public class BL_BillingInformation : EdiX12Segment
{
	[Position(01)]
	public string RebillReasonCode { get; set; }

	[Position(02)]
	public string FreightStationAccountingCode { get; set; }

	[Position(03)]
	public string FreightStationAccountingCode2 { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public string CityName { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(09)]
	public string CityName2 { get; set; }

	[Position(10)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(11)]
	public string CountryCode2 { get; set; }

	[Position(12)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(13)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(14)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(15)]
	public string StandardCarrierAlphaCode4 { get; set; }

	[Position(16)]
	public string StandardCarrierAlphaCode5 { get; set; }

	[Position(17)]
	public string StandardCarrierAlphaCode6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BL_BillingInformation>(this);
		validator.Required(x=>x.RebillReasonCode);
		validator.AtLeastOneIsRequired(x=>x.FreightStationAccountingCode, x=>x.CityName);
		validator.AtLeastOneIsRequired(x=>x.FreightStationAccountingCode2, x=>x.CityName2);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.ARequiresB(x=>x.StateOrProvinceCode2, x=>x.CityName2);
		validator.Length(x => x.RebillReasonCode, 2);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.FreightStationAccountingCode2, 1, 5);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.CityName2, 2, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.CountryCode2, 2, 3);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode4, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode5, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode6, 2, 4);
		return validator.Results;
	}
}
