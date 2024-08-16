using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("RLS")]
public class RLS_Relationship : EdifactSegment
{
	[Position(1)]
	public string RelationshipTypeCodeQualifier { get; set; }

	[Position(2)]
	public E941_Relationship Relationship { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RLS_Relationship>(this);
		validator.Required(x=>x.RelationshipTypeCodeQualifier);
		validator.Length(x => x.RelationshipTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
