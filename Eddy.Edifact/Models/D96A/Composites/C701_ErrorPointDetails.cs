using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C701")]
public class C701_ErrorPointDetails : EdifactComponent
{
	[Position(1)]
	public string MessageSectionCoded { get; set; }

	[Position(2)]
	public string MessageItemNumber { get; set; }

	[Position(3)]
	public string MessageSubItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C701_ErrorPointDetails>(this);
		validator.Required(x=>x.MessageSectionCoded);
		validator.Length(x => x.MessageSectionCoded, 1, 3);
		validator.Length(x => x.MessageItemNumber, 1, 35);
		validator.Length(x => x.MessageSubItemNumber, 1, 6);
		return validator.Results;
	}
}
