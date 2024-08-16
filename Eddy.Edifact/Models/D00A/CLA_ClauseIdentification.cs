using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CLA")]
public class CLA_ClauseIdentification : EdifactSegment
{
	[Position(1)]
	public string ClauseCodeQualifier { get; set; }

	[Position(2)]
	public C970_ClauseName ClauseName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLA_ClauseIdentification>(this);
		validator.Required(x=>x.ClauseCodeQualifier);
		validator.Length(x => x.ClauseCodeQualifier, 1, 3);
		return validator.Results;
	}
}
