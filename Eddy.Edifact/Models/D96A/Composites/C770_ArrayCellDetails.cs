using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C770")]
public class C770_ArrayCellDetails : EdifactComponent
{
	[Position(1)]
	public string ArrayCellInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C770_ArrayCellDetails>(this);
		validator.Length(x => x.ArrayCellInformation, 1, 35);
		return validator.Results;
	}
}
