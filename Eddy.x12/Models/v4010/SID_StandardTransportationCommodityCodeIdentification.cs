using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SID")]
public class SID_StandardTransportationCommodityCodeIdentification : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string RatingSummaryValueCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SID_StandardTransportationCommodityCodeIdentification>(this);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.RatingSummaryValueCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
