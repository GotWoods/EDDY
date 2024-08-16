using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CAV")]
public class CAV_CharacteristicValue : EdifactSegment
{
	[Position(1)]
	public C889_CharacteristicValue CharacteristicValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAV_CharacteristicValue>(this);
		validator.Required(x=>x.CharacteristicValue);
		return validator.Results;
	}
}
