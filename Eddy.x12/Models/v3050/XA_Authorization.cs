using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("XA")]
public class XA_Authorization : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string Authority { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XA_Authorization>(this);
		validator.Required(x=>x.Name);
		validator.Required(x=>x.CityName);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Required(x=>x.Authority);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Authority, 1, 20);
		return validator.Results;
	}
}
