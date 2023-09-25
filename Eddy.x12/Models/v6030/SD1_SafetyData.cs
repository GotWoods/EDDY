using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("SD1")]
public class SD1_SafetyData : EdiX12Segment
{
	[Position(01)]
	public string ItemDescriptionTypeCode { get; set; }

	[Position(02)]
	public string SafetyCharacteristicHazardCode { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string SourceSubqualifier { get; set; }

	[Position(05)]
	public string ProductDescriptionCode { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SD1_SafetyData>(this);
		validator.Required(x=>x.ItemDescriptionTypeCode);
		validator.Required(x=>x.SafetyCharacteristicHazardCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.AgencyQualifierCode, x=>x.ProductDescriptionCode, x=>x.Description);
		validator.AtLeastOneIsRequired(x=>x.ProductDescriptionCode, x=>x.Description);
		validator.ARequiresB(x=>x.ProductDescriptionCode, x=>x.AgencyQualifierCode);
		validator.Length(x => x.ItemDescriptionTypeCode, 1);
		validator.Length(x => x.SafetyCharacteristicHazardCode, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		return validator.Results;
	}
}
