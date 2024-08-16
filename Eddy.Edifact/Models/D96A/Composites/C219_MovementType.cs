using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C219")]
public class C219_MovementType : EdifactComponent
{
	[Position(1)]
	public string MovementTypeCoded { get; set; }

	[Position(2)]
	public string MovementType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C219_MovementType>(this);
		validator.Length(x => x.MovementTypeCoded, 1, 3);
		validator.Length(x => x.MovementType, 1, 35);
		return validator.Results;
	}
}
