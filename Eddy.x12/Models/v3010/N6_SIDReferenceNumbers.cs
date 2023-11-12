using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("N6")]
public class N6_SIDReferenceNumbers : EdiX12Segment
{
	[Position(01)]
	public string ShipmentIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N6_SIDReferenceNumbers>(this);
		validator.Required(x=>x.ShipmentIdentificationNumber);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		return validator.Results;
	}
}
