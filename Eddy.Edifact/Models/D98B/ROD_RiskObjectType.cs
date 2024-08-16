using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("ROD")]
public class ROD_RiskObjectType : EdifactSegment
{
	[Position(1)]
	public C851_RiskObjectType RiskObjectType { get; set; }

	[Position(2)]
	public C852_RiskObjectSubType RiskObjectSubType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ROD_RiskObjectType>(this);
		return validator.Results;
	}
}
