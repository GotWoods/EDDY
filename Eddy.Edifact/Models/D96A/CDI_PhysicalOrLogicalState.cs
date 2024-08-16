using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CDI")]
public class CDI_PhysicalOrLogicalState : EdifactSegment
{
	[Position(1)]
	public string PhysicalOrLogicalStateQualifier { get; set; }

	[Position(2)]
	public C564_PhysicalOrLogicalStateInformation PhysicalOrLogicalStateInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDI_PhysicalOrLogicalState>(this);
		validator.Required(x=>x.PhysicalOrLogicalStateQualifier);
		validator.Required(x=>x.PhysicalOrLogicalStateInformation);
		validator.Length(x => x.PhysicalOrLogicalStateQualifier, 1, 3);
		return validator.Results;
	}
}
