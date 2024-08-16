using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E962")]
public class E962_TerminalInformation : EdifactComponent
{
	[Position(1)]
	public string GateIdentifier { get; set; }

	[Position(2)]
	public string FirstRelatedLocationIdentifier { get; set; }

	[Position(3)]
	public string FirstRelatedLocationIdentifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E962_TerminalInformation>(this);
		validator.Length(x => x.GateIdentifier, 1, 6);
		validator.Length(x => x.FirstRelatedLocationIdentifier, 1, 35);
		validator.Length(x => x.FirstRelatedLocationIdentifier2, 1, 35);
		return validator.Results;
	}
}
