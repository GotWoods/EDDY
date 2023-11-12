using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("F9")]
public class F9_OriginStation : EdiX12Segment
{
	[Position(01)]
	public string FreightStationAccountingCode { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string FreightStationAccountingCode2 { get; set; }

	[Position(06)]
	public string CityName2 { get; set; }

	[Position(07)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(08)]
	public string StandardPointLocationCode { get; set; }

	[Position(09)]
	public string PostalCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F9_OriginStation>(this);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.FreightStationAccountingCode2, 1, 5);
		validator.Length(x => x.CityName2, 2, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.PostalCode, 3, 9);
		return validator.Results;
	}
}
