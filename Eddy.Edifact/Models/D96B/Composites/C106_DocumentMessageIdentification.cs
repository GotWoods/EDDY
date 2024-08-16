using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C106")]
public class C106_DocumentMessageIdentification : EdifactComponent
{
	[Position(1)]
	public string DocumentMessageNumber { get; set; }

	[Position(2)]
	public string Version { get; set; }

	[Position(3)]
	public string RevisionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C106_DocumentMessageIdentification>(this);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.RevisionNumber, 1, 6);
		return validator.Results;
	}
}
