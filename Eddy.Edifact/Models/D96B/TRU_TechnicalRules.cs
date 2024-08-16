using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("TRU")]
public class TRU_TechnicalRules : EdifactSegment
{
	[Position(1)]
	public string IdentityNumber { get; set; }

	[Position(2)]
	public string Version { get; set; }

	[Position(3)]
	public string Release { get; set; }

	[Position(4)]
	public string RulePartIdentification { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRU_TechnicalRules>(this);
		validator.Required(x=>x.IdentityNumber);
		validator.Length(x => x.IdentityNumber, 1, 35);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.Release, 1, 9);
		validator.Length(x => x.RulePartIdentification, 1, 7);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
