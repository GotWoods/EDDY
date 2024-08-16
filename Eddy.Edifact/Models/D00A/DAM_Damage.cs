using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DAM")]
public class DAM_Damage : EdifactSegment
{
	[Position(1)]
	public string DamageDetailsCodeQualifier { get; set; }

	[Position(2)]
	public C821_TypeOfDamage TypeOfDamage { get; set; }

	[Position(3)]
	public C822_DamageArea DamageArea { get; set; }

	[Position(4)]
	public C825_DamageSeverity DamageSeverity { get; set; }

	[Position(5)]
	public C826_Action Action { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DAM_Damage>(this);
		validator.Required(x=>x.DamageDetailsCodeQualifier);
		validator.Length(x => x.DamageDetailsCodeQualifier, 1, 3);
		return validator.Results;
	}
}