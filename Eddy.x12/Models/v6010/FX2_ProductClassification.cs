using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("FX2")]
public class FX2_ProductClassification : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string CommodityCodeQualifier { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FX2_ProductClassification>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.AtLeastOneIsRequired(x=>x.CommodityCode, x=>x.Description);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
