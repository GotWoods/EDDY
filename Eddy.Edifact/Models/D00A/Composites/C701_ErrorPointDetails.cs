using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C701")]
public class C701_ErrorPointDetails : EdifactComponent
{
	[Position(1)]
	public string MessageSectionCode { get; set; }

	[Position(2)]
	public string MessageItemIdentifier { get; set; }

	[Position(3)]
	public string MessageSubItemIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C701_ErrorPointDetails>(this);
		validator.Length(x => x.MessageSectionCode, 1, 3);
		validator.Length(x => x.MessageItemIdentifier, 1, 35);
		validator.Length(x => x.MessageSubItemIdentifier, 1, 6);
		return validator.Results;
	}
}
