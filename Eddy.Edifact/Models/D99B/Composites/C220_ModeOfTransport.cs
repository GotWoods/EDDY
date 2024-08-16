using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C220")]
public class C220_ModeOfTransport : EdifactComponent
{
	[Position(1)]
	public string TransportModeNameCode { get; set; }

	[Position(2)]
	public string TransportModeName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C220_ModeOfTransport>(this);
		validator.Length(x => x.TransportModeNameCode, 1, 3);
		validator.Length(x => x.TransportModeName, 1, 17);
		return validator.Results;
	}
}
