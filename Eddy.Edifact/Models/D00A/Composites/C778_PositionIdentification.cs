using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C778")]
public class C778_PositionIdentification : EdifactComponent
{
	[Position(1)]
	public string HierarchicalStructureLevelIdentifier { get; set; }

	[Position(2)]
	public string SequencePositionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C778_PositionIdentification>(this);
		validator.Length(x => x.HierarchicalStructureLevelIdentifier, 1, 35);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		return validator.Results;
	}
}
