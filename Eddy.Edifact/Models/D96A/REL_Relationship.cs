using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("REL")]
public class REL_Relationship : EdifactSegment
{
	[Position(1)]
	public string RelationshipQualifier { get; set; }

	[Position(2)]
	public C941_Relationship Relationship { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REL_Relationship>(this);
		validator.Required(x=>x.RelationshipQualifier);
		validator.Length(x => x.RelationshipQualifier, 1, 3);
		return validator.Results;
	}
}
