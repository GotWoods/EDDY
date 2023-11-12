using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("PDP")]
public class PDP_PropertyDescriptionPersonal : EdiX12Segment
{
	[Position(01)]
	public string TypeOfPersonalPropertyCode { get; set; }

	[Position(02)]
	public string CommodityCodeQualifier { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDP_PropertyDescriptionPersonal>(this);
		validator.Required(x=>x.TypeOfPersonalPropertyCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.Length(x => x.TypeOfPersonalPropertyCode, 2);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		return validator.Results;
	}
}
