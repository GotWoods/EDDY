using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E962")]
public class E962_TerminalInformation : EdifactComponent
{
	[Position(1)]
	public string GateIdentifier { get; set; }

	[Position(2)]
	public string FirstRelatedLocationNameCode { get; set; }

	[Position(3)]
	public string FirstRelatedLocationNameCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E962_TerminalInformation>(this);
		validator.Length(x => x.GateIdentifier, 1, 6);
		validator.Length(x => x.FirstRelatedLocationNameCode, 1, 25);
		validator.Length(x => x.FirstRelatedLocationNameCode2, 1, 25);
		return validator.Results;
	}
}
