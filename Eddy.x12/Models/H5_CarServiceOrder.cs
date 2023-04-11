using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("H5")]
public class H5_CarServiceOrder : EdiX12Segment
{
	[Position(01)]
	public string CarServiceOrderCode { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<H5_CarServiceOrder>(this);
		validator.Required(x=>x.CarServiceOrderCode);
		validator.Length(x => x.CarServiceOrderCode, 3, 5);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
