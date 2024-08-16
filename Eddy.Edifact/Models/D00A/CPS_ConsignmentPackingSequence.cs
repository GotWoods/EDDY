using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CPS")]
public class CPS_ConsignmentPackingSequence : EdifactSegment
{
	[Position(1)]
	public string HierarchicalStructureLevelIdentifier { get; set; }

	[Position(2)]
	public string HierarchicalStructureParentIdentifier { get; set; }

	[Position(3)]
	public string PackagingLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPS_ConsignmentPackingSequence>(this);
		validator.Required(x=>x.HierarchicalStructureLevelIdentifier);
		validator.Length(x => x.HierarchicalStructureLevelIdentifier, 1, 35);
		validator.Length(x => x.HierarchicalStructureParentIdentifier, 1, 35);
		validator.Length(x => x.PackagingLevelCode, 1, 3);
		return validator.Results;
	}
}
