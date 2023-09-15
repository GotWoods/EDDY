using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G22")]
public class G22_PricingInformation : EdiX12Segment
{
	[Position(01)]
	public string PrepricedOptionCode { get; set; }

	[Position(02)]
	public string PriceNewSuggestedRetail { get; set; }

	[Position(03)]
	public string MultiplePriceQuantity { get; set; }

	[Position(04)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G22_PricingInformation>(this);
		validator.Required(x=>x.PrepricedOptionCode);
		validator.Length(x => x.PrepricedOptionCode, 1);
		validator.Length(x => x.PriceNewSuggestedRetail, 2, 7);
		validator.Length(x => x.MultiplePriceQuantity, 1, 2);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
