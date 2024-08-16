using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C219")]
public class C219_MovementType : EdifactComponent
{
	[Position(1)]
	public string MovementTypeDescriptionCode { get; set; }

	[Position(2)]
	public string MovementTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C219_MovementType>(this);
		validator.Length(x => x.MovementTypeDescriptionCode, 1, 3);
		validator.Length(x => x.MovementTypeDescription, 1, 35);
		return validator.Results;
	}
}
