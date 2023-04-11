using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FX6")]
public class FX6_BrandLabel : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string BrandName { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FX6_BrandLabel>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.AtLeastOneIsRequired(x=>x.BrandName, x=>x.Description);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.BrandName, 1, 60);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
