using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S008")]
public class S008_MessageVersion : EdifactComponent
{
	[Position(1)]
	public string MessageVersionNumber { get; set; }

	[Position(2)]
	public string MessageReleaseNumber { get; set; }

	[Position(3)]
	public string AssociationAssignedCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S008_MessageVersion>(this);
		validator.Required(x=>x.MessageVersionNumber);
		validator.Required(x=>x.MessageReleaseNumber);
		validator.Length(x => x.MessageVersionNumber, 1, 3);
		validator.Length(x => x.MessageReleaseNumber, 1, 3);
		validator.Length(x => x.AssociationAssignedCode, 1, 6);
		return validator.Results;
	}
}
