using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("D9")]
public class D9_DestinationStation : EdiX12Segment
{
	[Position(01)]
	public string FreightStationAccountingCode { get; set; }

	[Position(02)]
	public string DestinationStation { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string BilledAtStationCode { get; set; }

	[Position(06)]
	public string CityName { get; set; }

	[Position(07)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(08)]
	public string StandardPointLocationCode { get; set; }

	[Position(09)]
	public string PostalCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<D9_DestinationStation>(this);
		validator.Required(x=>x.DestinationStation);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.DestinationStation, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.BilledAtStationCode, 1, 6);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.PostalCode, 4, 9);
		return validator.Results;
	}
}
