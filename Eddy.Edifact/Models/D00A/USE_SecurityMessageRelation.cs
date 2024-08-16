using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USE")]
public class USE_SecurityMessageRelation : EdifactSegment
{
	[Position(1)]
	public string MessageRelationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USE_SecurityMessageRelation>(this);
		validator.Required(x=>x.MessageRelationCoded);
		validator.Length(x => x.MessageRelationCoded, 1, 3);
		return validator.Results;
	}
}
