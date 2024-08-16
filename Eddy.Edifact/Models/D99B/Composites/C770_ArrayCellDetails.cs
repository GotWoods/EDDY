using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C770")]
public class C770_ArrayCellDetails : EdifactComponent
{
	[Position(1)]
	public string ArrayCellDataDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C770_ArrayCellDetails>(this);
		validator.Length(x => x.ArrayCellDataDescription, 1, 512);
		return validator.Results;
	}
}
