using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S005")]
public class S005_RecipientReferencePasswordDetails : EdifactComponent
{
	[Position(1)]
	public string RecipientReferencePassword { get; set; }

	[Position(2)]
	public string RecipientReferencePasswordQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S005_RecipientReferencePasswordDetails>(this);
		validator.Required(x=>x.RecipientReferencePassword);
		validator.Length(x => x.RecipientReferencePassword, 1, 14);
		validator.Length(x => x.RecipientReferencePasswordQualifier, 2);
		return validator.Results;
	}
}
