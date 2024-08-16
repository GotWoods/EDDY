using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

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

	[Position(5)]
	public string Version { get; set; }

	[Position(6)]
	public string RevisionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C503_DocumentMessageDetails>(this);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.DocumentMessageStatusCoded, 1, 3);
		validator.Length(x => x.DocumentMessageSource, 1, 70);
		validator.Length(x => x.LanguageCoded, 1, 3);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.RevisionNumber, 1, 6);
		return validator.Results;
	}
}
