using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5040;

[Segment("MS5")]
public class MS5_ShipmentRatesAndCharges : EdiX12Segment
{
	[Position(01)]
	public string DeclaredValue { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	[Position(04)]
	public string DeclaredValue2 { get; set; }

	[Position(05)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS5_ShipmentRatesAndCharges>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.FreightRate);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.CurrencyCode, x=>x.DeclaredValue, x=>x.DeclaredValue2);
		validator.Length(x => x.DeclaredValue, 2, 12);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.FreightRate, 1, 15);
		validator.Length(x => x.DeclaredValue2, 2, 12);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
