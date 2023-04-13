using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G22")]
public class G22_PrePricingInformation : EdiX12Segment
{
	[Position(01)]
	public string PrePricedOptionCode { get; set; }

	[Position(02)]
	public string PriceNewSuggestedRetail { get; set; }

	[Position(03)]
	public int? MultiplePriceQuantity { get; set; }

	[Position(04)]
	public string FreeFormMessage { get; set; }

	[Position(05)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G22_PrePricingInformation>(this);
		validator.Required(x=>x.PrePricedOptionCode);
		validator.Length(x => x.PrePricedOptionCode, 1);
		validator.Length(x => x.PriceNewSuggestedRetail, 2, 7);
		validator.Length(x => x.MultiplePriceQuantity, 1, 2);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
