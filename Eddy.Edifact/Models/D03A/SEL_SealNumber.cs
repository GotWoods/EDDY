using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Models.D03A;

[Segment("SEL")]
public class SEL_SealNumber : EdifactSegment
{
	[Position(1)]
	public string TransportUnitSealIdentifier { get; set; }

	[Position(2)]
	public C215_SealIssuer SealIssuer { get; set; }

	[Position(3)]
	public string SealConditionCode { get; set; }

	[Position(4)]
	public C208_IdentityNumberRange IdentityNumberRange { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEL_SealNumber>(this);
		validator.Length(x => x.TransportUnitSealIdentifier, 1, 35);
		validator.Length(x => x.SealConditionCode, 1, 3);
		return validator.Results;
	}
}
