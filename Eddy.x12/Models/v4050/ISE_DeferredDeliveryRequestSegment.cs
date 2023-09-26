using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("ISE")]
public class ISE_DeferredDeliveryRequestSegment : EdiX12Segment
{
	[Position(01)]
	public string InterchangeDeliveryDate { get; set; }

	[Position(02)]
	public string InterchangeDeliveryTime { get; set; }

	[Position(03)]
	public string InterchangeDeliveryTimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISE_DeferredDeliveryRequestSegment>(this);
		validator.Required(x=>x.InterchangeDeliveryDate);
		validator.Required(x=>x.InterchangeDeliveryTime);
		validator.Length(x => x.InterchangeDeliveryDate, 6);
		validator.Length(x => x.InterchangeDeliveryTime, 4);
		validator.Length(x => x.InterchangeDeliveryTimeCode, 2);
		return validator.Results;
	}
}
