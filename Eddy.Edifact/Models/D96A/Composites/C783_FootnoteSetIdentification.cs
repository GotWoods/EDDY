using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C783")]
public class C783_FootnoteSetIdentification : EdifactComponent
{
	[Position(1)]
	public string FootnoteSetIdentifier { get; set; }

	[Position(2)]
	public string IdentityNumberQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C783_FootnoteSetIdentification>(this);
		validator.Required(x=>x.FootnoteSetIdentifier);
		validator.Length(x => x.FootnoteSetIdentifier, 1, 35);
		validator.Length(x => x.IdentityNumberQualifier, 1, 3);
		return validator.Results;
	}
}
