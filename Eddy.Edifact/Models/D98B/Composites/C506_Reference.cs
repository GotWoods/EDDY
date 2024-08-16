using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("C506")]
public class C506_Reference : EdifactComponent
{
	[Position(1)]
	public string ReferenceQualifier { get; set; }

	[Position(2)]
	public string ReferenceNumber { get; set; }

	[Position(3)]
	public string LineNumber { get; set; }

	[Position(4)]
	public string ReferenceVersionNumber { get; set; }

	[Position(5)]
	public string RevisionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C506_Reference>(this);
		validator.Required(x=>x.ReferenceQualifier);
		validator.Length(x => x.ReferenceQualifier, 1, 3);
		validator.Length(x => x.ReferenceNumber, 1, 35);
		validator.Length(x => x.LineNumber, 1, 6);
		validator.Length(x => x.ReferenceVersionNumber, 1, 35);
		validator.Length(x => x.RevisionNumber, 1, 6);
		return validator.Results;
	}
}
