using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SMA")]
public class SMA_StationAddress : EdiX12Segment
{
	[Position(01)]
	public string AddressTypeCode { get; set; }

	[Position(02)]
	public string AddressInformation { get; set; }

	[Position(03)]
	public string CityName { get; set; }

	[Position(04)]
	public string StateOrProvinceCode { get; set; }

	[Position(05)]
	public string PostalCode { get; set; }

	[Position(06)]
	public string CompensationQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMA_StationAddress>(this);
		validator.Required(x=>x.AddressTypeCode);
		validator.Required(x=>x.AddressInformation);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Required(x=>x.PostalCode);
		validator.Required(x=>x.CompensationQualifier);
		validator.Length(x => x.AddressTypeCode, 1);
		validator.Length(x => x.AddressInformation, 1, 35);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PostalCode, 4, 9);
		validator.Length(x => x.CompensationQualifier, 1);
		return validator.Results;
	}
}
