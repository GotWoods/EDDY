using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RAF")]
public class RAF_RateAdjustmentFactor : EdiX12Segment
{
	[Position(01)]
	public string CommodityGeographicLogicalConnectorCode { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public string ChangeTypeCode { get; set; }

	[Position(04)]
	public int? Percent { get; set; }

	[Position(05)]
	public string RoundingRuleCode { get; set; }

	[Position(06)]
	public decimal? FactorAmount { get; set; }

	[Position(07)]
	public string ReferenceNumber { get; set; }

	[Position(08)]
	public string RateAdjustmentDescriptionCode { get; set; }

	[Position(09)]
	public string RateLevel { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RAF_RateAdjustmentFactor>(this);
		validator.Required(x=>x.CommodityGeographicLogicalConnectorCode);
		validator.Required(x=>x.RateValueQualifier);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Length(x => x.CommodityGeographicLogicalConnectorCode, 1);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.Percent, 1, 3);
		validator.Length(x => x.RoundingRuleCode, 1);
		validator.Length(x => x.FactorAmount, 1, 9);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.RateAdjustmentDescriptionCode, 1, 2);
		validator.Length(x => x.RateLevel, 1, 5);
		return validator.Results;
	}
}
