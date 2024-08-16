using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S307")]
public class S307_ReportReason : EdifactComponent
{
	[Position(1)]
	public string ReportReasonCoded { get; set; }

	[Position(2)]
	public string ReportReasonText { get; set; }

	[Position(3)]
	public string ReportLanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S307_ReportReason>(this);
		validator.Length(x => x.ReportReasonCoded, 1, 3);
		validator.Length(x => x.ReportReasonText, 1, 70);
		validator.Length(x => x.ReportLanguageCoded, 1, 3);
		return validator.Results;
	}
}
