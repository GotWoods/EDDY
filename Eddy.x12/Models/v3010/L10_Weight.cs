using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("L10")]
public class L10_Weight : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public string WeightQualifier { get; set; }

	[Position(03)]
	public string WeightUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L10_Weight>(this);
		validator.Required(x=>x.Weight);
		validator.Required(x=>x.WeightQualifier);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitQualifier, 1);
		return validator.Results;
	}
}
