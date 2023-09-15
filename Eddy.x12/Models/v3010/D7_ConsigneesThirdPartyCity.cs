using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("D7")]
public class D7_ConsigneesThirdPartyCity : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string PostalCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<D7_ConsigneesThirdPartyCity>(this);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PostalCode, 4, 9);
		validator.Length(x => x.CountryCode, 2);
		return validator.Results;
	}
}
