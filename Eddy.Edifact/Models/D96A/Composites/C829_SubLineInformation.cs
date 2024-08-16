using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C829")]
public class C829_SubLineInformation : EdifactComponent
{
	[Position(1)]
	public string SubLineIndicatorCoded { get; set; }

	[Position(2)]
	public string LineItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C829_SubLineInformation>(this);
		validator.Length(x => x.SubLineIndicatorCoded, 1, 3);
		validator.Length(x => x.LineItemNumber, 1, 6);
		return validator.Results;
	}
}
