using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("G43")]
public class G43_PromotionPriceListArea : EdiX12Segment
{
	[Position(01)]
	public string MarketAreaCodeQualifier { get; set; }

	[Position(02)]
	public string MarketAreaCodeIdentifier { get; set; }

	[Position(03)]
	public string FreeFormMessage { get; set; }

	[Position(04)]
	public string ClassOfTradeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G43_PromotionPriceListArea>(this);
		validator.Required(x=>x.MarketAreaCodeQualifier);
		validator.Length(x => x.MarketAreaCodeQualifier, 1, 3);
		validator.Length(x => x.MarketAreaCodeIdentifier, 1, 12);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.ClassOfTradeCode, 2);
		return validator.Results;
	}
}
