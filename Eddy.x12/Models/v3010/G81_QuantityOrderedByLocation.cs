using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G81")]
public class G81_QuantityOrderedByLocation : EdiX12Segment
{
	[Position(01)]
	public string StoreNumber { get; set; }

	[Position(02)]
	public decimal? QuantityOrdered { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G81_QuantityOrderedByLocation>(this);
		validator.Required(x=>x.StoreNumber);
		validator.Required(x=>x.QuantityOrdered);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.QuantityOrdered, 1, 9);
		return validator.Results;
	}
}
