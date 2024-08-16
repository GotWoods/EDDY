using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("BII")]
public class BII_StructureIdentification : EdifactSegment
{
	[Position(1)]
	public string IndexingStructureCodeQualifier { get; set; }

	[Position(2)]
	public C045_BillLevelIdentification BillLevelIdentification { get; set; }

	[Position(3)]
	public string ItemIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BII_StructureIdentification>(this);
		validator.Required(x=>x.IndexingStructureCodeQualifier);
		validator.Required(x=>x.BillLevelIdentification);
		validator.Length(x => x.IndexingStructureCodeQualifier, 1, 3);
		validator.Length(x => x.ItemIdentifier, 1, 35);
		return validator.Results;
	}
}
