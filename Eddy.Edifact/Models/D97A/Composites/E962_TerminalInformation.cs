using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E962")]
public class E962_TerminalInformation : EdifactComponent
{
	[Position(1)]
	public string GateIdentification { get; set; }

	[Position(2)]
	public string RelatedPlaceLocationOneIdentification { get; set; }

	[Position(3)]
	public string RelatedPlaceLocationOneIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E962_TerminalInformation>(this);
		validator.Length(x => x.GateIdentification, 1, 6);
		validator.Length(x => x.RelatedPlaceLocationOneIdentification, 1, 25);
		validator.Length(x => x.RelatedPlaceLocationOneIdentification2, 1, 25);
		return validator.Results;
	}
}
