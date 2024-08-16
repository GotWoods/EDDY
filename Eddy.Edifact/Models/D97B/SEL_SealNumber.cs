using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("SEL")]
public class SEL_SealNumber : EdifactSegment
{
	[Position(1)]
	public string SealNumber { get; set; }

	[Position(2)]
	public C215_SealIssuer SealIssuer { get; set; }

	[Position(3)]
	public string SealConditionCoded { get; set; }

	[Position(4)]
	public C208_IdentityNumberRange IdentityNumberRange { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEL_SealNumber>(this);
		validator.Length(x => x.SealNumber, 1, 10);
		validator.Length(x => x.SealConditionCoded, 1, 3);
		return validator.Results;
	}
}
