using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06B.Composites;

[Segment("C056")]
public class C056_ContactDetails : EdifactComponent
{
	[Position(1)]
	public string ContactIdentifier { get; set; }

	[Position(2)]
	public string ContactName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C056_ContactDetails>(this);
		validator.Length(x => x.ContactIdentifier, 1, 17);
		validator.Length(x => x.ContactName, 1, 256);
		return validator.Results;
	}
}
