using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C514")]
public class C514_SampleLocationDetails : EdifactComponent
{
	[Position(1)]
	public string SampleLocationCoded { get; set; }

	[Position(2)]
	public string SampleLocation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C514_SampleLocationDetails>(this);
		validator.Length(x => x.SampleLocationCoded, 1, 3);
		validator.Length(x => x.SampleLocation, 1, 35);
		return validator.Results;
	}
}