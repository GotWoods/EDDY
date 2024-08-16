using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("BII")]
public class BII_StructureIdentification : EdifactSegment
{
	[Position(1)]
	public string IndexingStructureQualifier { get; set; }

	[Position(2)]
	public C045_BillLevelIdentification BillLevelIdentification { get; set; }

	[Position(3)]
	public string ItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BII_StructureIdentification>(this);
		validator.Required(x=>x.IndexingStructureQualifier);
		validator.Required(x=>x.BillLevelIdentification);
		validator.Length(x => x.IndexingStructureQualifier, 1, 3);
		validator.Length(x => x.ItemNumber, 1, 35);
		return validator.Results;
	}
}
