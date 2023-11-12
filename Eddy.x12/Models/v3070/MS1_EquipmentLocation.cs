using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("MS1")]
public class MS1_EquipmentLocation : EdiX12Segment
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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS1_EquipmentLocation>(this);
		validator.OnlyOneOf(x=>x.CityName, x=>x.LongitudeCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.CityName, x=>x.StateOrProvinceCode, x=>x.CountryCode);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.ARequiresB(x=>x.CountryCode, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LongitudeCode, x=>x.LatitudeCode);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.LongitudeCode, 7);
		validator.Length(x => x.LatitudeCode, 7);
		return validator.Results;
	}
}
