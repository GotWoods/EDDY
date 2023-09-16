using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7020;

[Segment("TC2")]
public class TC2_Commodity : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TC2_Commodity>(this);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.Length(x => x.CommodityCodeQualifier, 1, 2);
		validator.Length(x => x.CommodityCode, 1, 30);
		return validator.Results;
	}
}
