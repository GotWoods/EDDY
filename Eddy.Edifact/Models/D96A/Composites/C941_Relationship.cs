using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C941")]
public class C941_Relationship : EdifactComponent
{
	[Position(1)]
	public string RelationshipCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Relationship { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C941_Relationship>(this);
		validator.Length(x => x.RelationshipCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Relationship, 1, 35);
		return validator.Results;
	}
}
