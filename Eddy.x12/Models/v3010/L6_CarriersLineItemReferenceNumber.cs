using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("L6")]
public class L6_CarriersLineItemReferenceNumber : EdiX12Segment
{
	[Position(01)]
	public string CarriersLineItemReferenceNumber { get; set; }

	[Position(02)]
	public string PickUpDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L6_CarriersLineItemReferenceNumber>(this);
		validator.Length(x => x.CarriersLineItemReferenceNumber, 3, 12);
		validator.Length(x => x.PickUpDate, 6);
		return validator.Results;
	}
}
