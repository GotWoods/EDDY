using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98A.Composites;

[Segment("C503")]
public class C503_DocumentMessageDetails : EdifactComponent
{
	[Position(1)]
	public string DocumentMessageNumber { get; set; }

	[Position(2)]
	public string DocumentMessageStatusCoded { get; set; }

	[Position(3)]
	public string DocumentMessageSource { get; set; }

	[Position(4)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C503_DocumentMessageDetails>(this);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.DocumentMessageStatusCoded, 1, 3);
		validator.Length(x => x.DocumentMessageSource, 1, 70);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
