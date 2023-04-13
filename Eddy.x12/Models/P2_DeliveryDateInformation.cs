using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("P2")]
public class P2_DeliveryDateInformation : EdiX12Segment
{
	[Position(01)]
	public string PickupOrDeliveryCode { get; set; }

	[Position(02)]
	public string DeliveryDate { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<P2_DeliveryDateInformation>(this);
		validator.Required(x=>x.DeliveryDate);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Length(x => x.PickupOrDeliveryCode, 1, 2);
		validator.Length(x => x.DeliveryDate, 8);
		validator.Length(x => x.DateTimeQualifier, 3);
		return validator.Results;
	}
}
