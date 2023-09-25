using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("DLV")]
public class DLV_DeliverableInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityOrdered { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DLV_DeliverableInformation>(this);
		validator.Required(x=>x.QuantityOrdered);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Length(x => x.QuantityOrdered, 1, 9);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		return validator.Results;
	}
}
