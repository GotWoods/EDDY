using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

[Segment("MS1")]
public class MS1_EquipmentShipmentOrRealPropertyLocation : EdiX12Segment
{
	[Position(01)]
	public string CityName { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string CountryCode { get; set; }

	[Position(04)]
	public string LongitudeCode { get; set; }

	[Position(05)]
	public string LatitudeCode { get; set; }

	[Position(06)]
	public string DirectionIdentifierCode { get; set; }

	[Position(07)]
	public string DirectionIdentifierCode2 { get; set; }

	[Position(08)]
	public string PostalCode { get; set; }

	[Position(09)]
	public decimal? LongitudeDecimalFormat { get; set; }

	[Position(10)]
	public decimal? LatitudeDecimalFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS1_EquipmentShipmentOrRealPropertyLocation>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.CityName, x=>x.StateOrProvinceCode, x=>x.CountryCode);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.ARequiresB(x=>x.CountryCode, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LongitudeCode, x=>x.LatitudeCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DirectionIdentifierCode, x=>x.LongitudeCode, x=>x.LongitudeDecimalFormat);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DirectionIdentifierCode2, x=>x.LatitudeCode, x=>x.LatitudeDecimalFormat);
		validator.ARequiresB(x=>x.PostalCode, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LongitudeDecimalFormat, x=>x.LatitudeDecimalFormat);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.LongitudeCode, 7, 10);
		validator.Length(x => x.LatitudeCode, 7, 10);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.DirectionIdentifierCode2, 1);
		validator.Length(x => x.PostalCode, 3, 15);
		validator.Length(x => x.LongitudeDecimalFormat, 1, 10);
		validator.Length(x => x.LatitudeDecimalFormat, 1, 10);
		return validator.Results;
	}
}
