using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UIR")]
public class UIR_InteractiveStatus : EdifactSegment
{
	[Position(1)]
	public string ReportFunctionCoded { get; set; }

	[Position(2)]
	public S307_ReportReason ReportReason { get; set; }

	[Position(3)]
	public S302_DialogueReference DialogueReference { get; set; }

	[Position(4)]
	public S300_DateAndOrTimeOfInitiation DateAndOrTimeOfInitiation { get; set; }

	[Position(5)]
	public string InteractiveMessageReferenceNumber { get; set; }

	[Position(6)]
	public string PackageReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UIR_InteractiveStatus>(this);
		validator.Required(x=>x.ReportFunctionCoded);
		validator.Length(x => x.ReportFunctionCoded, 1, 3);
		validator.Length(x => x.InteractiveMessageReferenceNumber, 1, 35);
		validator.Length(x => x.PackageReferenceNumber, 1, 35);
		return validator.Results;
	}
}
