using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("HYN")]
public class HYN_HierarchyInformation : EdifactSegment
{
	[Position(1)]
	public string HierarchyObjectQualifier { get; set; }

	[Position(2)]
	public string HierarchicalLevelCoded { get; set; }

	[Position(3)]
	public string ActionRequestNotificationCoded { get; set; }

	[Position(4)]
	public C212_ItemNumberIdentification ItemNumberIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HYN_HierarchyInformation>(this);
		validator.Required(x=>x.HierarchyObjectQualifier);
		validator.Required(x=>x.HierarchicalLevelCoded);
		validator.Length(x => x.HierarchyObjectQualifier, 1, 3);
		validator.Length(x => x.HierarchicalLevelCoded, 1, 3);
		validator.Length(x => x.ActionRequestNotificationCoded, 1, 3);
		return validator.Results;
	}
}
