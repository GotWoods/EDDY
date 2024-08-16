using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C829")]
public class C829_SubLineInformation : EdifactComponent
{
	[Position(1)]
	public string SubLineIndicatorCode { get; set; }

	[Position(2)]
	public string LineItemIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C829_SubLineInformation>(this);
		validator.Length(x => x.SubLineIndicatorCode, 1, 3);
		validator.Length(x => x.LineItemIdentifier, 1, 6);
		return validator.Results;
	}
}
