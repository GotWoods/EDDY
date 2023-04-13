using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IM")]
public class IM_IntermodalMovementInformation : EdiX12Segment
{
	[Position(01)]
	public string WaterMovementCode { get; set; }

	[Position(02)]
	public string SpecialHandlingCode { get; set; }

	[Position(03)]
	public string InlandTransportationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IM_IntermodalMovementInformation>(this);
		validator.Length(x => x.WaterMovementCode, 1);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.InlandTransportationCode, 2);
		return validator.Results;
	}
}
