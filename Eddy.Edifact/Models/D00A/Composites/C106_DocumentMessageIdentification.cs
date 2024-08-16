using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C106")]
public class C106_DocumentMessageIdentification : EdifactComponent
{
	[Position(1)]
	public string DocumentIdentifier { get; set; }

	[Position(2)]
	public string VersionIdentifier { get; set; }

	[Position(3)]
	public string RevisionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C106_DocumentMessageIdentification>(this);
		validator.Length(x => x.DocumentIdentifier, 1, 35);
		validator.Length(x => x.VersionIdentifier, 1, 9);
		validator.Length(x => x.RevisionIdentifier, 1, 6);
		return validator.Results;
	}
}
