using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070.Composites;

[Segment("C045")]
public class C045_ConditionsIndicated : EdiX12Component
{
	[Position(00)]
	public string ConditionIndicator { get; set; }

	[Position(01)]
	public string ConditionIndicator2 { get; set; }

	[Position(02)]
	public string ConditionIndicator3 { get; set; }

	[Position(03)]
	public string ConditionIndicator4 { get; set; }

	[Position(04)]
	public string ConditionIndicator5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C045_ConditionsIndicated>(this);
		validator.Required(x=>x.ConditionIndicator);
		validator.Length(x => x.ConditionIndicator, 2);
		validator.Length(x => x.ConditionIndicator2, 2);
		validator.Length(x => x.ConditionIndicator3, 2);
		validator.Length(x => x.ConditionIndicator4, 2);
		validator.Length(x => x.ConditionIndicator5, 2);
		return validator.Results;
	}
}
