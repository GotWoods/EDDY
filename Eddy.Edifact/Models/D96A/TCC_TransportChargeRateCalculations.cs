using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("TCC")]
public class TCC_TransportChargeRateCalculations : EdifactSegment
{
	[Position(1)]
	public C200_Charge Charge { get; set; }

	[Position(2)]
	public C203_RateTariffClass RateTariffClass { get; set; }

	[Position(3)]
	public C528_CommodityRateDetail CommodityRateDetail { get; set; }

	[Position(4)]
	public C554_RateTariffClassDetail RateTariffClassDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TCC_TransportChargeRateCalculations>(this);
		return validator.Results;
	}
}
