using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BER")]
public class BER_BeerInformation : EdiX12Segment
{
	[Position(01)]
	public string BeerStyle { get; set; }

	[Position(02)]
	public decimal? MeasurementValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BER_BeerInformation>(this);
		validator.Required(x=>x.BeerStyle);
		validator.Length(x => x.BeerStyle, 2, 3);
		validator.Length(x => x.MeasurementValue, 1, 20);
		return validator.Results;
	}
}
