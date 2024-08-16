using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C778")]
public class C778_PositionIdentification : EdifactComponent
{
	[Position(1)]
	public string HierarchicalIdNumber { get; set; }

	[Position(2)]
	public string SequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C778_PositionIdentification>(this);
		validator.Length(x => x.HierarchicalIdNumber, 1, 12);
		validator.Length(x => x.SequenceNumber, 1, 6);
		return validator.Results;
	}
}
