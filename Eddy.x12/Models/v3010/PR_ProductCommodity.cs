using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PR_ProductCommodity>(this);
		validator.Required(x=>x.CommodityGeographicLogicalConnectorCode);
		validator.Length(x => x.CommodityGeographicLogicalConnectorCode, 1);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.CommodityCode2, 1, 16);
		return validator.Results;
	}
}
