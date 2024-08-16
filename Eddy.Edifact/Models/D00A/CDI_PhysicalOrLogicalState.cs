using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CDI")]
public class CDI_PhysicalOrLogicalState : EdifactSegment
{
	[Position(1)]
	public string PhysicalOrLogicalStateTypeCodeQualifier { get; set; }

	[Position(2)]
	public C564_PhysicalOrLogicalStateInformation PhysicalOrLogicalStateInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDI_PhysicalOrLogicalState>(this);
		validator.Required(x=>x.PhysicalOrLogicalStateTypeCodeQualifier);
		validator.Required(x=>x.PhysicalOrLogicalStateInformation);
		validator.Length(x => x.PhysicalOrLogicalStateTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
