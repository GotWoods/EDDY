using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("CTP")]
public class CTP_PricingInformation : EdiX12Segment
{
	[Position(01)]
	public string ClassOfTradeCode { get; set; }

	[Position(02)]
	public string PriceIdentifierCode { get; set; }

	[Position(03)]
	public decimal? UnitPrice { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public string PriceMultiplierQualifier { get; set; }

	[Position(07)]
	public decimal? Multiplier { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string BasisOfUnitPriceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTP_PricingInformation>(this);
		validator.ARequiresB(x=>x.Quantity, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.PriceMultiplierQualifier, x=>x.Multiplier);
		validator.ARequiresB(x=>x.BasisOfUnitPriceCode, x=>x.PriceIdentifierCode);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.UnitPrice, 1, 14);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.BasisOfUnitPriceCode, 2);
		return validator.Results;
	}
}
