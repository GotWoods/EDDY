using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PR")]
public class PR_ProductCommodity : EdiX12Segment
{
	[Position(01)]
	public string CommodityGeographicLogicalConnectorCode { get; set; }

	[Position(02)]
	public string CommodityCodeQualifier { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string CommodityCode2 { get; set; }

	[Position(05)]
	public string ChangeTypeCode { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(07)]
	public string DocketControlNumber { get; set; }

	[Position(08)]
	public string DocketIdentification { get; set; }

	[Position(09)]
	public string GroupTitle { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PR_ProductCommodity>(this);
		validator.Required(x=>x.CommodityGeographicLogicalConnectorCode);
		validator.ARequiresB(x=>x.CommodityCode, x=>x.CommodityCodeQualifier);
		validator.Length(x => x.CommodityGeographicLogicalConnectorCode, 1);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.CommodityCode2, 1, 30);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.GroupTitle, 2, 30);
		return validator.Results;
	}
}
