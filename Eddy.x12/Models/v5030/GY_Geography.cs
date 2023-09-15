using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

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

	[Position(08)]
	public string ChangeTypeCode { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(10)]
	public string DocketControlNumber { get; set; }

	[Position(11)]
	public string DocketIdentification { get; set; }

	[Position(12)]
	public string GroupTitle { get; set; }

	[Position(13)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(14)]
	public string CityName { get; set; }

	[Position(15)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GY_Geography>(this);
		validator.Required(x=>x.GeographyQualifierCode);
		validator.OnlyOneOf(x=>x.LocationQualifier, x=>x.StandardCarrierAlphaCode2);
		validator.ARequiresB(x=>x.LocationIdentifier, x=>x.LocationQualifier);
		validator.ARequiresB(x=>x.LocationIdentifier2, x=>x.LocationIdentifier);
		validator.OnlyOneOf(x=>x.StandardCarrierAlphaCode2, x=>x.StateOrProvinceCode2);
		validator.OnlyOneOf(x=>x.StandardCarrierAlphaCode2, x=>x.YesNoConditionOrResponseCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StateOrProvinceCode2, x=>x.CityName);
		validator.Length(x => x.GeographyQualifierCode, 1);
		validator.Length(x => x.CommodityGeographicLogicalConnectorCode, 1);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.GroupTitle, 2, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
