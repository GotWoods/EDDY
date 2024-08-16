using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("APR")]
public class APR_AdditionalPriceInformation : EdifactSegment
{
	[Position(1)]
	public string TradeClassCode { get; set; }

	[Position(2)]
	public C138_PriceMultiplierInformation PriceMultiplierInformation { get; set; }

	[Position(3)]
	public C960_ReasonForChange ReasonForChange { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<APR_AdditionalPriceInformation>(this);
		validator.Length(x => x.TradeClassCode, 1, 3);
		return validator.Results;
	}
}
