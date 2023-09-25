using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("Q8")]
public class Q8_DetailDeliveryExceptionInformation : EdiX12Segment
{
	[Position(01)]
	public string LadingExceptionCode { get; set; }

	[Position(02)]
	public string PackagingFormCode { get; set; }

	[Position(03)]
	public int? LadingQuantity { get; set; }

	[Position(04)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(05)]
	public string ProductServiceID { get; set; }

	[Position(06)]
	public string LadingDescription { get; set; }

	[Position(07)]
	public string DamageReasonCode { get; set; }

	[Position(08)]
	public string ActionCode { get; set; }

	[Position(09)]
	public string ReferenceNumber { get; set; }

	[Position(10)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q8_DetailDeliveryExceptionInformation>(this);
		validator.Required(x=>x.LadingExceptionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PackagingFormCode, x=>x.LadingQuantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Length(x => x.LadingExceptionCode, 1);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.DamageReasonCode, 2);
		validator.Length(x => x.ActionCode, 1);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
