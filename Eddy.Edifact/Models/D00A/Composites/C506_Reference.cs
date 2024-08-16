using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C506")]
public class C506_Reference : EdifactComponent
{
	[Position(1)]
	public string ReferenceFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string ReferenceIdentifier { get; set; }

	[Position(3)]
	public string DocumentLineIdentifier { get; set; }

	[Position(4)]
	public string ReferenceVersionIdentifier { get; set; }

	[Position(5)]
	public string RevisionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C506_Reference>(this);
		validator.Required(x=>x.ReferenceFunctionCodeQualifier);
		validator.Length(x => x.ReferenceFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		validator.Length(x => x.DocumentLineIdentifier, 1, 6);
		validator.Length(x => x.ReferenceVersionIdentifier, 1, 35);
		validator.Length(x => x.RevisionIdentifier, 1, 6);
		return validator.Results;
	}
}
