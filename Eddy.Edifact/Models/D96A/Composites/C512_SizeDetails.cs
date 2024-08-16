using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C512")]
public class C512_SizeDetails : EdifactComponent
{
	[Position(1)]
	public string SizeQualifier { get; set; }

	[Position(2)]
	public string Size { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C512_SizeDetails>(this);
		validator.Length(x => x.SizeQualifier, 1, 3);
		validator.Length(x => x.Size, 1, 15);
		return validator.Results;
	}
}
