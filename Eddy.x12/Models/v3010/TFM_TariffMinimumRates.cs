using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TFM")]
public class TFM_TariffMinimumRates : EdiX12Segment
{
	[Position(01)]
	public decimal? FreightRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TFM_TariffMinimumRates>(this);
		validator.Required(x=>x.FreightRate);
		validator.Length(x => x.FreightRate, 1, 9);
		return validator.Results;
	}
}
