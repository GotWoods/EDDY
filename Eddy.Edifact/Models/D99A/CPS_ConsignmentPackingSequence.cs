using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("CPS")]
public class CPS_ConsignmentPackingSequence : EdifactSegment
{
	[Position(1)]
	public string HierarchicalIdNumber { get; set; }

	[Position(2)]
	public string HierarchicalParentId { get; set; }

	[Position(3)]
	public string PackagingLevelCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPS_ConsignmentPackingSequence>(this);
		validator.Required(x=>x.HierarchicalIdNumber);
		validator.Length(x => x.HierarchicalIdNumber, 1, 35);
		validator.Length(x => x.HierarchicalParentId, 1, 12);
		validator.Length(x => x.PackagingLevelCoded, 1, 3);
		return validator.Results;
	}
}
