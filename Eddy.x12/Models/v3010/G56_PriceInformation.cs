using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G56")]
public class G56_PriceInformation : EdiX12Segment
{
	[Position(01)]
	public string PriceBracketIdentifier { get; set; }

	[Position(02)]
	public string FreeFormMessage { get; set; }

	[Position(03)]
	public decimal? ItemListCostNew { get; set; }

	[Position(04)]
	public string PriceNewSuggestedRetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G56_PriceInformation>(this);
		validator.Required(x=>x.PriceBracketIdentifier);
		validator.Required(x=>x.ItemListCostNew);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.ItemListCostNew, 1, 9);
		validator.Length(x => x.PriceNewSuggestedRetail, 2, 7);
		return validator.Results;
	}
}
