using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("GY")]
public class GY_Geography : EdiX12Segment
{
	[Position(01)]
	public string GeographyQualifierCode { get; set; }

	[Position(02)]
	public string CommodityGeographicLogicalConnectorCode { get; set; }

	[Position(03)]
	public string LocationQualifier { get; set; }

	[Position(04)]
	public string StateOrProvinceCode { get; set; }

	[Position(05)]
	public string LocationIdentifier { get; set; }

	[Position(06)]
	public string LocationIdentifier2 { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GY_Geography>(this);
		validator.Required(x=>x.GeographyQualifierCode);
		validator.Required(x=>x.CommodityGeographicLogicalConnectorCode);
		validator.Length(x => x.GeographyQualifierCode, 1);
		validator.Length(x => x.CommodityGeographicLogicalConnectorCode, 1);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.LocationIdentifier2, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
