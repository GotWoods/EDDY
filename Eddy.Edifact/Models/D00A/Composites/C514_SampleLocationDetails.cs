using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C514")]
public class C514_SampleLocationDetails : EdifactComponent
{
	[Position(1)]
	public string SampleLocationDescriptionCode { get; set; }

	[Position(2)]
	public string SampleLocationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C514_SampleLocationDetails>(this);
		validator.Length(x => x.SampleLocationDescriptionCode, 1, 3);
		validator.Length(x => x.SampleLocationDescription, 1, 35);
		return validator.Results;
	}
}
