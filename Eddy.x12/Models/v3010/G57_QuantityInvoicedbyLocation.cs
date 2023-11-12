using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G57")]
public class G57_QuantityInvoicedByLocation : EdiX12Segment
{
	[Position(01)]
	public string StoreNumber { get; set; }

	[Position(02)]
	public decimal? QuantityInvoiced { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G57_QuantityInvoicedByLocation>(this);
		validator.Required(x=>x.StoreNumber);
		validator.Required(x=>x.QuantityInvoiced);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.QuantityInvoiced, 1, 10);
		return validator.Results;
	}
}
