using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G25")]
public class G25_FOBInformation : EdiX12Segment
{
	[Position(01)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(02)]
	public string FOBPointCode { get; set; }

	[Position(03)]
	public string FOBPoint { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G25_FOBInformation>(this);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Required(x=>x.FOBPointCode);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.FOBPointCode, 2);
		validator.Length(x => x.FOBPoint, 1, 30);
		return validator.Results;
	}
}
