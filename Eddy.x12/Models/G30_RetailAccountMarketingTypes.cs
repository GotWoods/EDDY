using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G30")]
public class G30_RetailAccountMarketingTypes : EdiX12Segment
{
	[Position(01)]
	public string MarketingTypeCode { get; set; }

	[Position(02)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G30_RetailAccountMarketingTypes>(this);
		validator.Required(x=>x.MarketingTypeCode);
		validator.Length(x => x.MarketingTypeCode, 1, 2);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
