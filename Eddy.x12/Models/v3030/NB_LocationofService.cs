using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("NB")]
public class NB_LocationOfService : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string StandardPointLocationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NB_LocationOfService>(this);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		return validator.Results;
	}
}
