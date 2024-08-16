using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C503")]
public class C503_DocumentMessageDetails : EdifactComponent
{
	[Position(1)]
	public string DocumentIdentifier { get; set; }

	[Position(2)]
	public string DocumentStatusCode { get; set; }

	[Position(3)]
	public string DocumentSourceDescription { get; set; }

	[Position(4)]
	public string LanguageNameCode { get; set; }

	[Position(5)]
	public string VersionIdentifier { get; set; }

	[Position(6)]
	public string RevisionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C503_DocumentMessageDetails>(this);
		validator.Length(x => x.DocumentIdentifier, 1, 35);
		validator.Length(x => x.DocumentStatusCode, 1, 3);
		validator.Length(x => x.DocumentSourceDescription, 1, 70);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.VersionIdentifier, 1, 9);
		validator.Length(x => x.RevisionIdentifier, 1, 6);
		return validator.Results;
	}
}
