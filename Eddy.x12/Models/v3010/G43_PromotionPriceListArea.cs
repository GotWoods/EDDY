using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G43")]
public class G43_PromotionPriceListArea : EdiX12Segment
{
	[Position(01)]
	public string MarketAreaCodeQualifier { get; set; }

	[Position(02)]
	public int? MarketAreaCodeNumber { get; set; }

	[Position(03)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G43_PromotionPriceListArea>(this);
		validator.Required(x=>x.MarketAreaCodeQualifier);
		validator.Length(x => x.MarketAreaCodeQualifier, 1, 3);
		validator.Length(x => x.MarketAreaCodeNumber, 1, 12);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
