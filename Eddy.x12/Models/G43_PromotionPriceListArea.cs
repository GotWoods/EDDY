using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G43")]
public class G43_PromotionPriceListArea : EdiX12Segment
{
	[Position(01)]
	public string MarketAreaCodeQualifier { get; set; }

	[Position(02)]
	public string MarketAreaCodeIdentifier { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string ClassOfTradeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G43_PromotionPriceListArea>(this);
		validator.Required(x=>x.MarketAreaCodeQualifier);
		validator.Length(x => x.MarketAreaCodeQualifier, 1, 3);
		validator.Length(x => x.MarketAreaCodeIdentifier, 1, 13);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ClassOfTradeCode, 2);
		return validator.Results;
	}
}
