using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("U9")]
public class U9_PriorOriginCity : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string PostalCode { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public string StandardPointLocationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<U9_PriorOriginCity>(this);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PostalCode, 4, 9);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		return validator.Results;
	}
}
