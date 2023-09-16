using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TFD")]
public class TFD_TariffAdjustmentsMinimumCharge : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public decimal? TariffAdjustmentValueAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TFD_TariffAdjustmentsMinimumCharge>(this);
		validator.Required(x=>x.RateValueQualifier);
		validator.Required(x=>x.TariffAdjustmentValueAmount);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.TariffAdjustmentValueAmount, 1, 9);
		return validator.Results;
	}
}
