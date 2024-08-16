using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S005")]
public class S005_RecipientsReferencePassword : EdifactComponent
{
	[Position(1)]
	public string RecipientsReferencePassword { get; set; }

	[Position(2)]
	public string RecipientsReferencePasswordQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S005_RecipientsReferencePassword>(this);
		validator.Required(x=>x.RecipientsReferencePassword);
		validator.Length(x => x.RecipientsReferencePassword, 1, 14);
		validator.Length(x => x.RecipientsReferencePasswordQualifier, 2);
		return validator.Results;
	}
}
