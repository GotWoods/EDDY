using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E778")]
public class E778_PositionIdentification : EdifactComponent
{
	[Position(1)]
	public string HierarchicalIdNumber { get; set; }

	[Position(2)]
	public string SequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E778_PositionIdentification>(this);
		validator.Length(x => x.HierarchicalIdNumber, 1, 35);
		validator.Length(x => x.SequenceNumber, 1, 10);
		return validator.Results;
	}
}
