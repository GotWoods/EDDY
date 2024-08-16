using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("HYN")]
public class HYN_HierarchyInformation : EdifactSegment
{
	[Position(1)]
	public string HierarchyObjectCodeQualifier { get; set; }

	[Position(2)]
	public string HierarchicalLevelCoded { get; set; }

	[Position(3)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(4)]
	public C212_ItemNumberIdentification ItemNumberIdentification { get; set; }

	[Position(5)]
	public string HierarchicalStructureParentIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HYN_HierarchyInformation>(this);
		validator.Required(x=>x.HierarchyObjectCodeQualifier);
		validator.Length(x => x.HierarchyObjectCodeQualifier, 1, 3);
		validator.Length(x => x.HierarchicalLevelCoded, 1, 3);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.HierarchicalStructureParentIdentifier, 1, 35);
		return validator.Results;
	}
}
