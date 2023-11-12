using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("CTP")]
public class CTP_PricingInformation : EdiX12Segment
{
	[Position(01)]
	public string ClassOfTradeCode { get; set; }

	[Position(02)]
	public string PriceQualifier { get; set; }

	[Position(03)]
	public decimal? UnitPrice { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(06)]
	public string PriceMultiplierQualifier { get; set; }

	[Position(07)]
	public decimal? Multiplier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTP_PricingInformation>(this);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.PriceQualifier, 3);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		return validator.Results;
	}
}
