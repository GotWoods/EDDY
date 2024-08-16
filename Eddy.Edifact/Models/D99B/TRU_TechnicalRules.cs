using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("TRU")]
public class TRU_TechnicalRules : EdifactSegment
{
	[Position(1)]
	public string ObjectIdentifier { get; set; }

	[Position(2)]
	public string Version { get; set; }

	[Position(3)]
	public string Release { get; set; }

	[Position(4)]
	public string RulePartIdentification { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRU_TechnicalRules>(this);
		validator.Required(x=>x.ObjectIdentifier);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.Release, 1, 9);
		validator.Length(x => x.RulePartIdentification, 1, 7);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
