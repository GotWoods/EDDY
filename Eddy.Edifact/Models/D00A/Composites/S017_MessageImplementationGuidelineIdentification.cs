using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S017")]
public class S017_MessageImplementationGuidelineIdentification : EdifactComponent
{
	[Position(1)]
	public string MessageImplementationGuidelineIdentification { get; set; }

	[Position(2)]
	public string MessageImplementationGuidelineVersionNumber { get; set; }

	[Position(3)]
	public string MessageImplementationGuidelineReleaseNumber { get; set; }

	[Position(4)]
	public string ControllingAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S017_MessageImplementationGuidelineIdentification>(this);
		validator.Required(x=>x.MessageImplementationGuidelineIdentification);
		validator.Length(x => x.MessageImplementationGuidelineIdentification, 1, 14);
		validator.Length(x => x.MessageImplementationGuidelineVersionNumber, 1, 3);
		validator.Length(x => x.MessageImplementationGuidelineReleaseNumber, 1, 3);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		return validator.Results;
	}
}
