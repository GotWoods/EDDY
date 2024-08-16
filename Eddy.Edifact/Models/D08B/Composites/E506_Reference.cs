using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E506")]
public class E506_Reference : EdifactComponent
{
	[Position(1)]
	public string ReferenceCodeQualifier { get; set; }

	[Position(2)]
	public string ReferenceIdentifier { get; set; }

	[Position(3)]
	public string DocumentLineIdentifier { get; set; }

	[Position(4)]
	public string ReferenceVersionIdentifier { get; set; }

	[Position(5)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E506_Reference>(this);
		validator.Required(x=>x.ReferenceCodeQualifier);
		validator.Length(x => x.ReferenceCodeQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.DocumentLineIdentifier, 1, 6);
		validator.Length(x => x.ReferenceVersionIdentifier, 1, 35);
		validator.Length(x => x.PartyName, 1, 70);
		return validator.Results;
	}
}
