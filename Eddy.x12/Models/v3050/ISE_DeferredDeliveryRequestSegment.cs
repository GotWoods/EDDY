using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("ISE")]
public class ISE_DeferredDeliveryRequestSegment : EdiX12Segment
{
	[Position(01)]
	public string DeliveryDate { get; set; }

	[Position(02)]
	public string DeliveryTime { get; set; }

	[Position(03)]
	public string DeliveryTimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISE_DeferredDeliveryRequestSegment>(this);
		validator.Required(x=>x.DeliveryDate);
		validator.Required(x=>x.DeliveryTime);
		validator.Length(x => x.DeliveryDate, 6);
		validator.Length(x => x.DeliveryTime, 4);
		validator.Length(x => x.DeliveryTimeCode, 2);
		return validator.Results;
	}
}
