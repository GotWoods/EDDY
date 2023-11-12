using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7020;

[Segment("PDP")]
public class PDP_PropertyDescriptionPersonal : EdiX12Segment
{
	[Position(01)]
	public string TypeOfPersonalOrBusinessAssetCode { get; set; }

	[Position(02)]
	public string CommodityCodeQualifier { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDP_PropertyDescriptionPersonal>(this);
		validator.Required(x=>x.TypeOfPersonalOrBusinessAssetCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.Length(x => x.TypeOfPersonalOrBusinessAssetCode, 2);
		validator.Length(x => x.CommodityCodeQualifier, 1, 2);
		validator.Length(x => x.CommodityCode, 1, 30);
		return validator.Results;
	}
}
